using KisiselBlog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace KisiselBlog.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;



		RKisiselBlogContext db=new RKisiselBlogContext();
		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index(int id)
		{
			RKisiselBlogContext db = new RKisiselBlogContext();
			var sayfa = db.Sayfalars.Where(a => a.Silindi == false && a.Aktif == true && a.SayfaId == id).FirstOrDefault();
			return View(sayfa);
		}

		[HttpGet]
		public IActionResult kullaniciekle()
		{

			return View();
		}

		[HttpPost]
		public IActionResult kullaniciekle(Kullanicilar k)
		{
			k.Silindi = false;
			k.Aktif = true;
			k.Yetki = false;
			k.Parola = MD5Sifrele(k.Parola.Trim());
			db.Kullanicilars.Add(k);
			db.SaveChanges();
			TempData["mesaj"] = "Kullanıcı ekleme başarılı";
			return Redirect("/Home/Index/");
		}

		public IActionResult iletisim(Iletisim ilt)
		{
			ilt.Silindi = false;
			ilt.Aktif = false;
			ilt.Eklenmetarihi = DateTime.Now;
			db.Iletisims.Add(ilt);
			db.SaveChanges();
			TempData["mesaj"] = "iletişim talebiniz alınmıştır ";
			return Redirect("/Home/Index" );
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

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
