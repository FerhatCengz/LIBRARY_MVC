using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class GaleriController : Controller
    {
        // GET: Galeri
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase dosya)
        {
            if (dosya.ContentLength > 0)
            {
                string dosyaYolu = Path.Combine(Server.MapPath("~/image/"),Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyaYolu);
            }
            
            return View();
        }
    }
}