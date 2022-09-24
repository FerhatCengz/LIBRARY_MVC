using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MvcKutuphane.Models.Entity;
namespace MvcKutuphane.Controllers
{
    public class PersonelController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Personel
        public ActionResult PersonelListe()
        {
            return View(db.Tbl_Personel.ToList());
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Tbl_Personel p)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            db.Tbl_Personel.Add(p);
            db.SaveChangesAsync();
            return RedirectToAction("PersonelListe");
        }
        public ActionResult PersonelSil(int id = 0)
        {
            TRYCATHPROCESS tr = new TRYCATHPROCESS();
            tr.tryIslemleri(id, db.Tbl_Personel);
            return RedirectToAction("PersonelListe");
        }
        [HttpGet]
        public ActionResult PersonelGuncelle(int id)
        {
            return View(db.Tbl_Personel.Find(id));
        }

        [HttpPost]
        public ActionResult PersonelGuncelle(Tbl_Personel p1)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var queryUpdate = db.Tbl_Personel.Find(p1.ID);
            queryUpdate.PERSONEL = p1.PERSONEL;
            db.SaveChanges();
            return RedirectToAction("PersonelListe");
        }
    }


}