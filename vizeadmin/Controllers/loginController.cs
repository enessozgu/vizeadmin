using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vizeadmin.Models;
using vizeadmin.Controllers;
using vizeadmin.Models.Entity;



namespace vizeadmin.Controllers
{
    public class loginController : Controller
    {
        Dbo_yemektarifEntities1 db = new Dbo_yemektarifEntities1();
        // GET: login
        public ActionResult login()
        {
            return View();
        }
        public ActionResult ilkekran()
        {
            return View();
        }

        public ActionResult yeniogrenci()
        {
            return View();
        }




        public ActionResult panel()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ekle()
		{
            return View();
		}

        [HttpPost]
        public ActionResult ekle(ogrenciler p3)
        {
            db.ogrenciler.Add(p3);
            db.SaveChanges();

            // Ana sayfaya yönlendir
            return RedirectToAction("panel");
        }


        public ActionResult akademisyenler()
        {
            var akademisyenler = db.akademisyen.ToList();
            return View(akademisyenler);
        }

        public ActionResult ogrenciler()
        {
            return View();
        }

        public ActionResult girisogrenci()
        {
            return View();
        }

        public ActionResult loginogrenci()
        {
            return View();
        }

        public ActionResult idari()
        {
            var idari = db.idari.ToList();
            return View(idari);
           
        }

        [HttpPost]
        public ActionResult login(FormCollection fc)
        {
            string kullaniciAdi = fc["username"];
            string sifre = fc["password"];

            // Örnek kullanıcı adı ve şifre kontrolü
            if (kullaniciAdi == "enes" && sifre == "enes")
            {
                Session["Yetki"] = kullaniciAdi;
                return RedirectToAction("panel", "login"); // Ana sayfaya yönlendir
            }
            else
            {
                ViewBag.ErrorMessage = "Geçersiz kullanıcı adı veya şifre!";
                return View();
            }
        }








        public ActionResult Index()
        {
            var ogrenciler = db.ogrenciler.ToList();
            return View(ogrenciler);
        }


        public ActionResult Sil(int id)
        {
            var ogrenci = db.ogrenciler.Find(id);
            db.ogrenciler.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



































    }
}
