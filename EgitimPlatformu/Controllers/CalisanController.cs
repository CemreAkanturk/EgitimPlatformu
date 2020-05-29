using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EgitimPlatformu.Controllers
{
    public class CalisanController : Controller
    {
        // GET: Calisan
        public ActionResult CalisanDersler()
        {
            return View();
        }
        public ActionResult DersBilgileri()
        {
            return View();
        }
        public ActionResult OnlineDers()
        {
            return View();
        }
        public ActionResult SınıfIcıDers()
        {
            return View();
        }
    }
}