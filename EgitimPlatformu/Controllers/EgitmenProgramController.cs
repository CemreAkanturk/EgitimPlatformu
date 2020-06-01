using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EgitimPlatformu.Controllers
{
    public class EgitmenProgramController : Controller
    {
        // GET: EgitmenProgram
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TakipListe()
        {
            return View();
        }
    }
}