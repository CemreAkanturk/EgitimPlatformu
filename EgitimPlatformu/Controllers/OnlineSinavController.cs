using DataLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities.ViewModel;
using Entities.ViewModel.OnlineSinav;

namespace EgitimPlatformu.Controllers
{
    public class OnlineSinavController : Controller
    {
        DataContext db = new DataContext();

        // GET: OnlineSinav
        public ActionResult Index()
        {
            var dersler = db.OnlineDers.ToList();

            //List<SelectListItem> model = new List<SelectListItem>();
           
            //foreach (var item in dersler)
            //{
            //    model.Add(new SelectListItem()
            //    {
            //        Value = item.OnlineId.ToString(),
            //        Text = item.Dersler.DersAdi,

            //    }); ;

            //}


            return View(dersler);
        }


        [HttpGet]
        public JsonResult SeanslarGetir()
        {
            var Seanslar = db.OnlineIcerik.ToList();

            List<SelectListItem> model = new List<SelectListItem>();

            foreach (var item in Seanslar)
            {
                model.Add(new SelectListItem()
                {
                    Value = item.OnlineId.ToString(),
                    Text = item.OnlineIcerikId.ToString(),
                   

                }); ;

            }
            return Json(model, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Sorular(int id)
        {
            var gelen = db.OnlineIcerik.Find(id);

            return View();
        }



    }
}