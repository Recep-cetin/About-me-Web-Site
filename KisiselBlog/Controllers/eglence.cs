using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using KisiselBlog.Models;

namespace KisiselBlog.Controllers
{
	public class eglence : Controller
	{
    RKisiselBlogContext db = new RKisiselBlogContext(); 
		public IActionResult Index()
		{
			return View();
		}
        public IActionResult konubasi(yashesaplama yas)
        {
            return View(yas);
        }
        [HttpGet]
        public IActionResult yashesapla()
        {
            return View();
        }
        [HttpPost]
        public IActionResult yashesapla(yashesaplama yas)
        {

            return View("konubasi", yas);
        }
        public string yasısım(string isim, int dgt)
        {
            dgt = 2022 - dgt;
            return isim + " " + dgt.ToString();
        }

        public IActionResult YorumYap(Yorumlar yor)
        {
            yor.Silindi = false;
            yor.Aktif = false;
            yor.Eklenmetarihi = DateTime.Now;
            db.Yorumlars.Add(yor);
            db.SaveChanges();
            TempData["mesaj"] = "Yorumunuz alındı, yönetici onayından sonra görünecektir";
            return Redirect("/eglence/Index/" );
        }


    }
}
