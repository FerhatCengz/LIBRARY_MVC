using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using System.Web.Security;
namespace MvcKutuphane.Controllers
{

    public class MesajlarController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Mesajlar

        [HttpGet]
        public ActionResult MesajIndex()
        {
            //var userInfo = (string)HttpContext.User.Identity.Name;
            var userInfo = (string)Session["MAIL"];

            return View(db.Tbl_Mesajlar.Where(x => x.ALICI == userInfo).ToList());
        }

        [HttpGet]
        public ActionResult YeniMesaj(string result = "")
        {
            ViewBag.result = result;
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(Tbl_Mesajlar setMsj)
        {
            var aliciControl = db.Tbl_Uyeler.Any(x => x.MAIL == setMsj.ALICI);
            if (aliciControl)
            {
                setMsj.GONDEREN = (string)Session["MAIL"];
                setMsj.TARIH = DateTime.Now;
                db.Tbl_Mesajlar.Add(setMsj);
                db.SaveChangesAsync();
                return RedirectToAction("YeniMesaj", "Mesajlar", new { result = "success" });
            }
            return RedirectToAction("YeniMesaj", "Mesajlar", new { result = "error" });

        }

        public ActionResult GonderilmisMesajlar()
        {
            string sessionUser = (string)Session["MAIL"];

            return View(db.Tbl_Mesajlar.Where(x => x.GONDEREN == sessionUser).OrderByDescending(x => x.TARIH).ToList());
        }
    }
}