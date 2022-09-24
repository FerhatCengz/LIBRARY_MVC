using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MvcKutuphane.Models.Entity;
using System.IO;
using System.Web.Security;
namespace MvcKutuphane.Controllers
{
    public class PanelimController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        [HttpGet]
        public ActionResult Index(string mesaj = "")
        {
            ViewBag.mesaj = mesaj;
            return View();
        }
        [HttpPost]
        public ActionResult Index(Tbl_Uyeler uye, string eskiSifre = "", string PASS1 = "", string PASS2 = "")
        {
            string userInfo = HttpContext.User.Identity.Name.ToString();
            var queryUpdate = db.Tbl_Uyeler.FirstOrDefault(x => x.MAIL == userInfo);
            if (PASS1 == PASS2 && queryUpdate.PASS == eskiSifre)
            {
                queryUpdate.PASS = PASS1;
                db.SaveChanges();
                return RedirectToAction("Index", "Panelim", new { mesaj = "success" });
            }

            return RedirectToAction("Index", "Panelim", new { mesaj = "unsuccessful" });

        }

        public JsonResult ResimGuncelle(string updatePhotoName = "")
        {


            if (Request.FilePath.Length > 0)
            {
                string userInfo = (string)HttpContext.User.Identity.Name;
                var queryPhotoUpdate = db.Tbl_Uyeler.FirstOrDefault(x => x.MAIL == userInfo);
                Request.Files[0].SaveAs(Server.MapPath("/image/" + userInfo + "_" + updatePhotoName));
                queryPhotoUpdate.USERPHOTO = "/image/" + userInfo + "_" + updatePhotoName;
                db.SaveChanges();
            }
            return Json(new { respone = "success" }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Kitaplarim()
        {
            return View();
        }

        public ActionResult LoginOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Login");
        }
    }
}

