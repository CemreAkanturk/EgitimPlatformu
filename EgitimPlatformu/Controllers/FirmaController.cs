using DataLayer.EntityFramework;
using Entities.ViewModel.Firma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EgitimPlatformu.Controllers
{
    public class FirmaController : Controller
    {
        DataContext db = new DataContext();
        // GET: Firma
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult DersBilgileri(int id)
        {

            var ders = db.Dersler.Find(id);
            SatilanDerslerVM model = new SatilanDerslerVM();

            model.DersAdi = ders.DersAdi;
            model.Aciklma = ders.Aciklama;
            model.Ucret = ders.Ucret;

            if (ders.EgitimTuru == 0)
            {
                model.SeansSayisi = db.SinifIciIcerik.Where(x => x.SinifIciDers.Dersler.DersId == id).Count();
            }
            else
            {
                model.SeansSayisi = db.OnlineIcerik.Where(x => x.OnlineDers.Dersler.DersId == id).Count();
            }

            model.SorSayisi= db.Sorular.Where(x => x.OnlineIcerik.OnlineDers.Dersler.DersId == id).Count();
            model.DersId = id;
            return Json(model, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public JsonResult DersSatinAl(int id)
        {
            var ders = db.Dersler.Find(id);
            var firma = db.Firma.Find(1);

            
            db.Dersler.Attach(ders);
            db.Firma.Attach(firma);
            ders.firmalar.Add(firma);
            db.SaveChanges();


            return Json(true, JsonRequestBehavior.AllowGet);

        }

    }
}