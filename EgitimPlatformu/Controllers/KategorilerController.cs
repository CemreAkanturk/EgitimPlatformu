using DataLayer.EntityFramework;
using Entities;
using Entities.ViewModel.Kategori;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EgitimPlatformu.Controllers
{
    public class KategorilerController : Controller
    {

        DataContext db = new DataContext();
        // GET: Kategoriler
        public ActionResult Index()
        {
            var kategoriler = db.Kategoriler.ToList();
            KategoriIndexVM model = new KategoriIndexVM()
            {
                Kategoriler = kategoriler,
                Bolumler = db.Bolum.Select(x => new SelectListItem() { Text = x.BolumAdi, Value = x.BolumId.ToString() }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult YeniKategori(Kategoriler yenikategori)
        {
            if (ModelState.IsValid)
            { 
                db.Kategoriler.Add(yenikategori);
                db.SaveChanges();
            }


            return RedirectToAction("Index");
        }

        public ActionResult Sil(int kategoriId)
        {

            var SilinecekKategori = db.Kategoriler.Find(kategoriId);
            if (ModelState.IsValid)
            {
                db.Kategoriler.Remove(SilinecekKategori);
                var derslerlist = db.Dersler.Where(x => x.KategoriId == kategoriId).ToList();
                db.Dersler.RemoveRange(derslerlist);
             
                foreach(var ders in derslerlist)
                {
                    var Ders = db.SinifIciDers.Find(ders.DersId);
                    db.SinifIciDers.Remove(Ders);
                }
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Guncelle(Kategoriler p)
        {
           
            if (ModelState.IsValid)
            {
                db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}