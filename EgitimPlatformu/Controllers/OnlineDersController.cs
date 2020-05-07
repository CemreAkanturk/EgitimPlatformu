using DataLayer.EntityFramework;
using Entities;
using Entities.InputModel;
using Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EgitimPlatformu.Controllers
{
    public class OnlineDersController : Controller
    {
        // GET: OnlineDers

        DataContext db = new DataContext();
        public ActionResult Index()
        {
            var onlineDerslerim = db.Dersler.Where(x=>x.EgitimTuru==1).ToList();
            return View(onlineDerslerim);
            
        }

        [HttpPost]
        public JsonResult Search(string arananstring)
        {
            var Derslerim = db.Dersler.Where(x => x.DersAdi.Contains(arananstring)&&x.EgitimTuru==1).ToList();

            List<SelectListItem> model = new List<SelectListItem>();

            foreach (var item in Derslerim)
            {
                model.Add(new SelectListItem()
                {
                    Value = item.DersId.ToString(),
                    Text = item.DersAdi,

                }); ;

            }
            return Json(model, JsonRequestBehavior.AllowGet);

        }


        public ActionResult DersEkle()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DersEkle(OnlineDersEkleIM yeniDers, HttpPostedFileBase DersAfis)
        {
            string path = "/Content/img/DersAfisleri/";


            if (DersAfis != null)
            {


                string fileName = Path.GetFileName(DersAfis.FileName);
                var combinedName = Path.Combine(path, fileName);
                if (!Directory.Exists(Server.MapPath(path)))
                {
                    Directory.CreateDirectory(Server.MapPath(path));
                }
                DersAfis.SaveAs(Server.MapPath(path + fileName));
                yeniDers.DersAfis = combinedName;
            }


            Dersler model = new Dersler
            {
                DersId = yeniDers.DersId,
                DersAdi = yeniDers.DersAdi,
                DersKodu = yeniDers.DersKodu,
                KategoriId = yeniDers.KategoriId,
                Aciklama = yeniDers.Aciklama,
                EgitimTuru = 1,
                EgitmenId = 2,
                DersAfis = yeniDers.DersAfis,
                OnlineDers = new OnlineDers
                { 
                    OnlineId = yeniDers.OnlineId,
                    OgrenimHedefleri = yeniDers.OgrenimHedefleri,
                    OrtamGereklilikleri = yeniDers.OrtamGereklilikleri,
                    Medya = yeniDers.Medya,
                    BasarimOlcutleri = yeniDers.BasarımOlcutleri,
                    Sure=yeniDers.Sure,
                },
            };


            db.Dersler.Add(model);
            db.SaveChanges();


            return RedirectToAction("Index");


        }


        public ActionResult Sil(int DersId)
        {
            Dersler secilenDers = db.Dersler.Find(DersId);
            OnlineDers secilenOnlineiciDers = db.OnlineDers.Find(DersId);
            if (ModelState.IsValid)
            {
                db.OnlineDers.Remove(secilenOnlineiciDers);
                db.Dersler.Remove(secilenDers);

                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }

        public ActionResult Duzenle(int id)
        {
            var ders = db.Dersler.Find(id);
            var online = db.OnlineDers.Find(id);

            OnlineDersDuzenle model = new OnlineDersDuzenle();

            model.dersler = ders;
            model.onlineDers = online;

            return View(model);
        }

    }
}