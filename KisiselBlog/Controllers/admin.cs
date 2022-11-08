using KisiselBlog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Threading.Tasks;

namespace KisiselBlog.Controllers
{
	[Authorize(Roles = "Admin")]//bu sayede kimse giris yapmadan buraya ulasamaz
	public class admin : Controller
	{
		RKisiselBlogContext db = new RKisiselBlogContext();
	

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult bilgilerim()
		{   //bu metod saysesinde giris sayfasından gelen
			int kid=Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
			var KulaniciId = db.Kullanicilars.Find(kid);
			KulaniciId.Parola = "";			
			return View(KulaniciId);
		}

		
		public IActionResult bilgilerimguncele(Kullanicilar kln)
		{
			var kulan = db.Kullanicilars.Where(s => s.Silindi == false && s.KulaniciId == kln.KulaniciId).FirstOrDefault();
			kulan.Adi = kln.Adi;
			kulan.Soyadi = kln.Soyadi;
			kulan.Telefon = kln.Telefon;
			kulan.Eposta = kln.Eposta;

			try
			{
				if (!String.IsNullOrEmpty(kln.Parola.Trim()))
				{
					kulan.Parola = MD5Sifrele(kln.Parola.Trim());
				}
			}
			catch (Exception)
			{

			}
			db.Kullanicilars.Update(kulan);
			db.SaveChanges();
			return RedirectToAction("bilgilerim");
		}

		public IActionResult kullanicilar()
		{
			var kulan = db.Kullanicilars.Where(s => s.Silindi == false).ToList();
			return View(kulan);
			
		}

		public IActionResult kullaniciekle()
		{

			return View();
		}

		[HttpPost]
		public IActionResult kullaniciekle(Kullanicilar k)
		{
			k.Silindi = false;
			k.Parola = MD5Sifrele(k.Parola.Trim());
			db.Kullanicilars.Add(k);
			db.SaveChanges();
			return RedirectToAction("kullanicilar");
		}

		public IActionResult kullanicigetir(int id)
		{
			var kullanici = db.Kullanicilars.Where(s => s.Silindi == false && s.KulaniciId == id).FirstOrDefault();
			kullanici.Parola = "";
			return View("kullaniciguncele", kullanici);
		}

		public IActionResult kullaniciguncele(Kullanicilar kln)
		{
			var kulan = db.Kullanicilars.Where(s => s.Silindi == false && s.KulaniciId == kln.KulaniciId).FirstOrDefault();
			kulan.Adi = kln.Adi;
			kulan.Soyadi = kln.Soyadi;
			kulan.Telefon = kln.Telefon;
			kulan.Eposta = kln.Eposta;
			kulan.Yetki = kln.Yetki;
			kulan.Aktif=kln.Aktif;
			try
			{
				if (!String.IsNullOrEmpty(kln.Parola.Trim()))
				{
					kulan.Parola = MD5Sifrele(kln.Parola.Trim());
				}
			}
			catch (Exception)
			{
 
			}
			db.Kullanicilars.Update(kulan);
			db.SaveChanges();
			return RedirectToAction("Kullanicilar");
		}

		public static string MD5Sifrele(string sifrelenecekMetin)
		{
			// MD5CryptoServiceProvider sınıfının bir örneğini oluşturduk.
			MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
			//Parametre olarak gelen veriyi byte dizisine dönüştürdük.
			byte[] dizi = Encoding.UTF8.GetBytes(sifrelenecekMetin);
			//dizinin hash'ini hesaplattık.
			dizi = md5.ComputeHash(dizi);
			//Hashlenmiş verileri depolamak için StringBuilder nesnesi oluşturduk.
			StringBuilder sb = new StringBuilder();
			//Her byte'i dizi içerisinden alarak string türüne dönüştürdük.

			foreach (byte ba in dizi)
			{
				sb.Append(ba.ToString("x2").ToLower());
			}
			//hexadecimal(onaltılık) stringi geri döndürdük.
			return sb.ToString();
		}

		public IActionResult kulanicisil(int id)
		{
			var kulan = db.Kullanicilars.Where(s => s.Silindi == false && s.KulaniciId == id).FirstOrDefault();
			kulan.Silindi = true;
			db.Kullanicilars.Update(kulan);
			db.SaveChanges();
			return RedirectToAction("Kullanicilar");
		}
		public IActionResult sayfalar()
		{
			var sayfalar = db.Sayfalars.Where(s=>s.Silindi==false).OrderBy(s=>s.Baslik).ToList();
			return View(sayfalar);
		}

		public IActionResult ekle()
		{
			
			return View();
		}

		[HttpPost]
		public IActionResult ekle(Sayfalar s)
		{
			
				s.Silindi = false;
				db.Sayfalars.Add(s);
				db.SaveChanges();
						
			return RedirectToAction("sayfalar");
		}

		public IActionResult sayfagetir(int id)
		{
			var sayfa= db.Sayfalars.Where(s=>s.Silindi==false && s.SayfaId == id).FirstOrDefault();	
			return View("sayfalarGuncelle",sayfa);
		}

		public IActionResult sayfalarGuncelle(Sayfalar syf)
		{
			var sayfa = db.Sayfalars.Where(s=>s.Silindi == false && s.SayfaId == syf.SayfaId).FirstOrDefault();
			sayfa.Baslik = syf.Baslik;	
			sayfa.Icerik = syf.Icerik;	
			sayfa.Aktif = syf.Aktif;
			db.Sayfalars.Update(sayfa);
			db.SaveChanges();
			return View("sayfalar");
		}

		public IActionResult sayfasil (int id)
		{
			var sayfa = db.Sayfalars.Where(s => s.Silindi == false && s.SayfaId == id).FirstOrDefault();
			sayfa.Silindi= true;	
			db.Sayfalars.Update(sayfa);
			db.SaveChanges();
			return RedirectToAction("sayfalar");
		
		}

		public IActionResult sayfayorumlari(int id)
		{
			var yorumlar =db.Yorumlars.Where(y=>y.Silindi ==false && y.SayfaId==id).OrderByDescending(y=>y.Eklenmetarihi).ToList();	
			return View(yorumlar);
		}
		//[HttpGet]
		public IActionResult yorumlar()
		{
			var yorum = db.Yorumlars.Include(k=>k.Sayfa).Include(k=>k.Kulanici).Where(y => y.Silindi == false).ToList();
			return View(yorum);
		}
		[HttpPost]
		public IActionResult yorumlar(string listelemetipi)
		{ 
			var yorumlar = db.Yorumlars.Where(y => y.Silindi == false).OrderByDescending(y => y.Eklenmetarihi).ToList();
			switch (listelemetipi)
			{
				case "onaylı": yorumlar = db.Yorumlars.Where(y => y.Silindi == false && y.Aktif == true).ToList(); break;
				case "onaysız": yorumlar = db.Yorumlars.Where(y => y.Silindi == false && y.Aktif == false).ToList(); break;

			}

			return View(yorumlar);
		}

		public IActionResult onay(int id)
		{
			var yorum = db.Yorumlars.Where(y => y.Silindi == false && y.YorumId == id).FirstOrDefault();
			yorum.Aktif = Convert.ToBoolean((-1*Convert.ToInt32(yorum.Aktif))+1);
			db.Yorumlars.Update(yorum);
			db.SaveChanges();
			return RedirectToAction("yorumlar");
		}

		public IActionResult onaysil(int id)
		{
			var yorum = db.Yorumlars.Where(y => y.Silindi == false && y.YorumId == id).FirstOrDefault();
			yorum.Silindi = true;
			db.Yorumlars.Update(yorum);
			db.SaveChanges();
			return RedirectToAction("yorumlar");
		}

		public IActionResult menuler()
		{
			var menu = db.Menulers.Where(s => s.Silindi == false).ToList();
			return View(menu);
		}

		public IActionResult menuekle()
		{

			return View();
		}

		[HttpPost]
		public IActionResult menuekle(Menuler m)
		{
			m.Silindi = false;
			db.Menulers.Add(m);
			db.SaveChanges();
			return RedirectToAction("Menuler");
		}

		public IActionResult menugetir(int id)
		{
			var menu = db.Menulers.Where(s => s.Silindi == false && s.MenuId == id).FirstOrDefault();
			return View("menuguncele", menu);
		}

		public IActionResult menuguncele(Menuler men)
		{
			var menu = db.Menulers.Where(s => s.Silindi == false && s.MenuId == men.MenuId).FirstOrDefault();
			menu.Baslik = men.Baslik;
			menu.Url = men.Url;
			menu.Sira = men.Sira;
			menu.UstId = men.UstId;
			menu.Aktif = men.Aktif;
			db.Menulers.Update(menu);
			db.SaveChanges();
			return RedirectToAction("Menuler");
		}

		public IActionResult menusil(int id)
		{
			var menu = db.Menulers.Where(s => s.Silindi == false && s.MenuId == id).FirstOrDefault();
			menu.Silindi = true;
			db.Menulers.Update(menu);
			db.SaveChanges();
			return RedirectToAction("Menuler");
		}
		public IActionResult iletisim()
		{
			var ilet = db.Iletisims.Where(s => s.Silindi == false).ToList();
			return View(ilet);
		}

		public IActionResult iletisimsil(int id)
		{
			var ilet = db.Iletisims.Where(y => y.Silindi == false && y.IletisimId == id).FirstOrDefault();
			ilet.Silindi = true;
			db.Iletisims.Update(ilet);
			db.SaveChanges();
			return RedirectToAction("iletisim");
		}

		public async Task<IActionResult> cikisyap()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Index", "Home");
		}
	}
}
