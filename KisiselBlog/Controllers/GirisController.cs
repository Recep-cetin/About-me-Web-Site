using KisiselBlog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using System;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace KisiselBlog.Controllers
{
	//

	public class Giriskontrol : Controller
	{
		public IActionResult Girisyap()
		{
			return View();
		}

		//[HttpPost]
		//public async Task<IActionResult> GirisYap(Kullanicilar k, string ReturnUrl)
		//{
		//	RKisiselBlogContext db = new RKisiselBlogContext();
		//	var kullanici = db.Kullanicilars.FirstOrDefault(kul => kul.Eposta == k.Eposta && kul.Parola == MD5Sifrele(k.Parola) && kul.Silindi == false && kul.Aktif == true);
		//	if (kullanici != null)
		//	{
		//		string yetki = (bool)kullanici.Yetki ? "Admin" : "Kullanici";
		//		var talepler = new List<Claim>()
		//		{
		//			new Claim(ClaimTypes.Email,kullanici.Eposta),
		//			new Claim(ClaimTypes.Role,yetki),
		//			new Claim(ClaimTypes.NameIdentifier,kullanici.KulaniciId.ToString())
		//		};
		//		ClaimsIdentity kimlik = new ClaimsIdentity(talepler, "Login");
		//		ClaimsPrincipal kural = new ClaimsPrincipal(kimlik);
		//		await HttpContext.SignInAsync(kural);
		//		if (!string.IsNullOrEmpty(ReturnUrl))
		//		{
		//			return Redirect(ReturnUrl);
		//		}
		//		else
		//		{
		//			if ((bool)kullanici.Yetki)
		//			{
		//				return Redirect("/Admin/Index");
		//			}
		//			else
		//			{
		//				return Redirect("/Home/Index");
		//			}
		//		}
		//	}
		//	return View();
		//}

		[HttpPost]
		public async Task<IActionResult> GirisYap(Kullanicilar k, string ReturnUrl)
		{
			RKisiselBlogContext db = new RKisiselBlogContext();
			var kullanici = db.Kullanicilars.FirstOrDefault(kul => kul.Eposta == k.Eposta && kul.Parola == MD5Sifrele(k.Parola) && kul.Silindi == false && kul.Aktif == true);
			if (kullanici != null)
			{
				string yetki = (bool)kullanici.Yetki ? "Admin" : "Kullanici";

				var talepler = new List<Claim>()
				{
					new Claim(ClaimTypes.Email,kullanici.Eposta),
					new Claim(ClaimTypes.Role,yetki),
					new Claim(ClaimTypes.NameIdentifier,kullanici.KulaniciId.ToString())
				};
				ClaimsIdentity kimlik = new ClaimsIdentity(talepler, "Login");
				ClaimsPrincipal kural = new ClaimsPrincipal(kimlik);
				await HttpContext.SignInAsync(kural);
				if (!string.IsNullOrEmpty(ReturnUrl))
				{
					return Redirect(ReturnUrl);
				}
				else
				{
					if ((bool)kullanici.Yetki)
					{
						return Redirect("/admin/Index");
					}
					else
					{
						return Redirect("/Home/Index");
					}
				}
			}
			return View();
		}

		public async Task<IActionResult> CikisYap()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Index", "Home");
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
	}
}
