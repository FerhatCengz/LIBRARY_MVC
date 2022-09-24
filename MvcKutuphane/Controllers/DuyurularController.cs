using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MvcKutuphane.Models.Entity;
namespace MvcKutuphane.Controllers
{
    public class DuyurularController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult DuyuruIndex()
        {
            return View(db.Tbl_Duyurular.ToList());
        }

        [HttpGet]
        public ActionResult DuyuruOlustur(Tbl_Duyurular duyuru, string result = "", string islem = "")
        {
            ViewBag.result = result;
            ViewBag.guncelle = islem;


            return View(db.Tbl_Duyurular.ToList());
        }

        [HttpPost]
        public ActionResult DuyuruOlustur(Tbl_Duyurular d, string islem = "", string newTitle = "", string a = "")
        {
            if (d.DUYUBASLIK != "" && d.DUYURUICERIK != "" && islem != "guncelle")
            {
                d.DUYURUICERIK += " " + DateTime.Now.ToShortDateString();
                db.Tbl_Duyurular.Add(d);
                db.SaveChanges();
                return RedirectToAction("DuyuruOlustur", "Duyurular", new { result = "success" });
            }


            if (islem == "guncelle")
            {
                var query = db.Tbl_Duyurular.FirstOrDefault(x => x.DUYUBASLIK == d.DUYUBASLIK);
                var updateQuery = db.Tbl_Duyurular.Find(query.ID);
                updateQuery.DUYUBASLIK = newTitle;
                updateQuery.DUYURUICERIK = d.DUYURUICERIK + " " + DateTime.Now.ToShortDateString();
                db.SaveChanges();

                return RedirectToAction("DuyuruOlustur", "Duyurular", new { result = "success" });


            }

            return RedirectToAction("DuyuruOlustur", "Duyurular", new { result = "error" });

        }
    }
}