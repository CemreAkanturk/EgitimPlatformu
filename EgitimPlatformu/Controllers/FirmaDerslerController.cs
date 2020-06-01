using DataLayer.EntityFramework;
using Entities.ViewModel.Firma;
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
            var dersler= (
            // instance from context
            from a in db.Firma
                // instance from navigation property
            from b in a.dersler
                //join to bring useful data
            join c in db.Dersler on b.DersId equals c.DersId
            where a.FirmaId == 1
            select new DerslerimVM
            {
                DersId = c.DersId,
                DersAdi = c.DersAdi,
                EgitmenAdi=c.Egitmen.Ad,
                EgitimTur=c.EgitimTuru,
            }).ToList();

            return View(dersler);
        }
        public ActionResult DersBilgiler(int id)
        {
            var egitmen = db.Egitmen.Find(1);
            var ders = db.Dersler.Find(id);
            var katilimcilar = db.Kisi.ToList();
           

            DersBilgilerimVM model = new DersBilgilerimVM();

            if (ders.EgitimTuru == 0)
            {
                model.SeansSayisi = db.SinifIciIcerik.Where(x => x.SinifIciDers.Dersler.DersId == id).Count();
            }
            else
            {
                model.SeansSayisi = db.OnlineIcerik.Where(x => x.OnlineDers.Dersler.DersId == id).Count();
            }


            model.ders = ders;
            model.egitmen = egitmen;
            model.katilimcilar = katilimcilar;
            return View(model);
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
            List<TarihPlanlamaVM> model = new List<TarihPlanlamaVM>();
            var dersler = db.SinifIciDers.ToList();

            foreach (var item in dersler)
            {
                var seanslar = db.SinifIciIcerik.Where(x => x.SinifIciId == item.SinifIciId).ToList();
                var seansSayisi = db.SinifIciIcerik.Where(x => x.SinifIciId == item.SinifIciId).Count();
                model.Add(new TarihPlanlamaVM()
                {
                    DersAdi=item.Dersler.DersAdi,
                    EgitmenAdi=item.Dersler.Egitmen.Ad,
                    seanslar=seanslar,
                    SeansSayisi=seansSayisi
                }); ;

            }

            return View(model);
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
