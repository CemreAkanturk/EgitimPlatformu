using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EgitimPlatformu.Controllers
{
    public class FirmaDerslerController : Controller
    {
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
            return View();
        }
        public ActionResult KatilimciPlanlama()
        {
            return View();
        }
    }
}
