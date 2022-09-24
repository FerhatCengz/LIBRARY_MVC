using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Page400()
        {
            Response.StatusCode = 400;
            return View();
        }
        public ActionResult Page402()
        {
            Response.StatusCode = 402;
            return View();
        }

        public ActionResult Page404()
        {
            Response.StatusCode = 404;
            return View();
        }
    }
}