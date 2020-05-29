using DataLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities.ViewModel;
using Entities.ViewModel.OnlineSinav;
using Entities;

namespace EgitimPlatformu.Controllers
{
    public class OnlineSinavController : Controller
    {
        DataContext db = new DataContext();

        // GET: OnlineSinav
        public ActionResult Index()
        {
            var dersler = db.OnlineDers.ToList();

            List<Sinavindex> model = new List<Sinavindex>();
         
            foreach (var item in dersler)
            {
                  List<Seanslar> seanslarVM = new List<Seanslar>();

                var Seanslar = db.OnlineIcerik.Where(x => x.OnlineId == item.OnlineId).ToList();

                if (Seanslar.Count != 0) { 
                foreach(var seans in Seanslar)
                {
                    seanslarVM.Add(new Seanslar()
                    {
                        Seansid= seans.OnlineIcerikId,
                        SeansAdi = seans.SeansAciklama,

                    });

                }
                }
                else
                {

                    seanslarVM.Add(new Seanslar()
                    {
                        Seansid = 0,
                        SeansAdi = "Yok",

                    });

                }

                model.Add(new Sinavindex()
                {
                    Dersİsim = item.Dersler.DersAdi,
                    seanslar= seanslarVM,

                });
                

            }


            return View(model);
        }


      
        public ActionResult Sorular(int id)
        {
            var gelenSeans = db.OnlineIcerik.Find(id);
            var gelenSorular = db.Sorular.Where(x => x.OnlineIcerikId == id).ToList();
            var gelenSeansTuru = gelenSeans.CevapTipi;
            List<CoktanSecmeliSoruVM> model = new List<CoktanSecmeliSoruVM>();
            if (gelenSorular.Count() == 0) {

                model.Add(new CoktanSecmeliSoruVM()
                {
                    OnlineIcerikID = id,
                    soruMetin = "Sorusuz",
                    Secenek1 = "Yok",
                    Secenek2 = "Yok",
                    Secenek3 = gelenSeansTuru,
                    Secenek4 = "Yok",
                    Cevap = 0,
                });

            }
            else { 

            for (int i = 0; i < gelenSorular.Count(); i++)
            {


                var soruid = gelenSorular[i].SoruId;

                if (gelenSeans.CevapTipi == "DY")
                {
                    var cevapp = "";
                    var cevap = db.DogruYanlisSorular.Find(soruid);
                    if (cevap.DogruSecenek == 1) {
                        cevapp = "Dogru";
                    }
                    else{
                        cevapp = "Yanlıs";
                    }

                    if (cevap != null)
                    {
                        model.Add(new CoktanSecmeliSoruVM()
                        {   OnlineIcerikID= id,
                            soruMetin = gelenSorular[i].Sorular1,
                            Secenek1 = cevapp,
                            Secenek2 = "Yok",
                            Secenek3 = gelenSeansTuru,
                            Secenek4 = "Yok",
                            Cevap = cevap.DogruSecenek,
                        });;
                    }
                 

                }
                else
                {

                    var soru = db.CoktanSecmeliSorular.Find(soruid);

                    if (soru != null)
                    {
                        model.Add(new CoktanSecmeliSoruVM()
                        {
                            OnlineIcerikID = id,
                            soruMetin = gelenSorular[i].Sorular1,
                            Secenek1 = soru.Secenek1,
                            Secenek2 = soru.Secenek2,
                            Secenek3 = soru.Secenek3,
                            Secenek4 = soru.Secenek4,
                            Cevap = soru.Cevap,
                        });
                    }
                  


                }

            }

            }
            return View(model);
        }

        public ActionResult Coklu(int id)
        {
            ViewData["seansid"] = id;
            return View();
        }

        public ActionResult DY(int id)
        {
            ViewData["seansid"] = id;
            return View();
        }

        [HttpPost]
        public ActionResult DYEkle(DySoruEkle sorular)
        {

            Sorular model = new Sorular
            {
                SoruId = sorular.SoruId,
                OnlineIcerikId = sorular.OnlineIcerikId,
                Sorular1 = sorular.Sorular1,
                DogruYanlisSorular = new DogruYanlisSorular
                {
                    DogruYanlisSorularId = sorular.DogruYanlisSorularId,
                    DogruSecenek=sorular.DogruSecenek,
                },
            };


            db.Sorular.Add(model);
            db.SaveChanges();

            return RedirectToAction("Sorular", new { id = sorular.OnlineIcerikId });
        }


        [HttpPost]
        public ActionResult CokluEkle(CokluSoruEkle sorular)
        {

            Sorular model = new Sorular
            {
                SoruId = sorular.SoruId,
                OnlineIcerikId = sorular.OnlineIcerikId,
                Sorular1 = sorular.Sorular1,
                CoktanSecmeliSorular = new CoktanSecmeliSorular
                {
                    CoktanSecmeliSorularId = sorular.CoktanSecmeliSorularId,
                    Secenek1 = sorular.Secenek1,
                    Secenek2 = sorular.Secenek2,
                    Secenek3 = sorular.Secenek3,
                    Secenek4 = sorular.Secenek4,
                    Cevap=sorular.Cevap
                },
            };


            db.Sorular.Add(model);
            db.SaveChanges();

            return RedirectToAction("Sorular", new { id = sorular.OnlineIcerikId });
        }
    }
}