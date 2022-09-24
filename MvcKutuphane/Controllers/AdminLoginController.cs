using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult AdminIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminIndex(Tbl_Admin p)
        {
            //var query = db.Tbl_Admin.FirstOrDefault(x => x.KAD == p.KAD && x.PASS == p.PASS);
            var query = db.Tbl_Admin.Any(x => x.KAD == p.KAD && x.PASS == p.PASS);
            if (query)
            {
                FormsAuthentication.SetAuthCookie(p.KAD, false);
                Session["KAD"] = p.KAD;
                return RedirectToAction("KategoriIndex", "Kategori");
            }
            return View();
        }
    }
}