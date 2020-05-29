using DataLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EgitimPlatformu.Controllers
{
    public class FirmaDerslerController : Controller
    {
        DataContext db = new DataContext();
         
        // GET: FirmaDersler
        public ActionResult Derslerim()
        {
            return View();
        }
        public ActionResult DersBilgiler()
        {
            return View();
        }
        public ActionResult SatilanDersler()
        {
            var SatilanDersler = db.Dersler.ToList();

            return View(SatilanDersler);
        }
        public ActionResult KatilimciPlanlama()
        {
            var KatılımcıPlanlama = db.Dersler.ToList(); 

            return View(KatılımcıPlanlama);
        }
        public ActionResult katilimciList(int id)
        {
            var gelenid = id;
            var katilimcilist = db.Kisi.ToList();
            return View(katilimcilist);
        }
        public ActionResult dersCalisanEkle()
        {
            return View();
        }
        public ActionResult dersTarihiPlanlama()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Sil(string kisiId)
        {
            var silinecek = db.Kisi.Find(kisiId);
            db.Kisi.Remove(silinecek);
            db.SaveChanges();
            return RedirectToAction("katilimciList");

        }
        public ActionResult Odeme()
        {
            return View();
        }
    
    }
}
