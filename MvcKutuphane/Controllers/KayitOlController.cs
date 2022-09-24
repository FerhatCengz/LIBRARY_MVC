using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class KayitOlController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: KayitOl
        [HttpGet]
        public ActionResult KayitIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KayitIndex(Tbl_Uyeler saveUye)
        {
            db.Tbl_Uyeler.Add(saveUye);
            saveUye.USERPHOTO = "/image/nullPerson.png";
            db.SaveChangesAsync();
            return RedirectToAction("GirisYap", "Login");
        }
    }
}