using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MvcKutuphane.Models.Entity;
using MvcKutuphane.Models.Siniflarim;
namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class VitrinController : Controller
    {
        // GET: Vitrin
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        [HttpGet]
        public ActionResult Index()
        {

            VitrinVeHakkimizdaJoin join = new VitrinVeHakkimizdaJoin();
            join.tbl_Hakkimizdas = db.Tbl_Hakkimizda.ToList();
            join.tbl_Kitaps = db.Tbl_Kitap.ToList();
            return View(join);
        }

        [HttpPost]
        public ActionResult Index(Tbl_Iletisim p)
        {
            db.Tbl_Iletisim.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}