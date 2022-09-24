using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class IstatikController : Controller
    {
        // GET: Istatik
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LinqCard()
        {

            return View();
        }
    }
}