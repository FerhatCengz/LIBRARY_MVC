using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using System.Data.Entity;
using System.Web.Security;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Login
        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(Tbl_Uyeler p)
        {
            //var usersInfo = db.Tbl_Uyeler.FirstOrDefault(x => x.MAIL == p.MAIL && x.PASS == p.PASS); // Varsa İlk Değeri
            var userInfo2 = db.Tbl_Uyeler.Any(x => x.MAIL == p.MAIL && x.PASS == p.PASS); // Varsa True


            if (userInfo2)
            {
                FormsAuthentication.SetAuthCookie(p.MAIL, false);
                Session["MAIL"] = p.MAIL;


                return RedirectToAction("Index", "Panelim");
            }

            return View();

        }
    }
}