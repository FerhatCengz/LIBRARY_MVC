using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
namespace MvcKutuphane.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult IndexListe()
        {
            var toList = db.Tbl_Yazar.ToList();
            return View(toList);
        }

        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YazarEkle(Tbl_Yazar p1)
        {
            db.Tbl_Yazar.Add(p1);
            db.SaveChanges();
            return RedirectToAction("IndexListe");
        }

        [HttpGet]
        public ActionResult YazariSil(int id)
        {
            var gelenVeriDegeri = db.Tbl_Yazar.Find(id);
            db.Tbl_Yazar.Remove(gelenVeriDegeri);
            db.SaveChanges();
            return RedirectToAction("IndexListe");
        }
        [HttpPost]
        public ActionResult YazariSil(int[] gelenVeriIdleri)
        {
            foreach (var x in gelenVeriIdleri)
            {
                var getToValueDelete = db.Tbl_Yazar.Find(x);
                db.Tbl_Yazar.Remove(getToValueDelete);
                db.SaveChanges();
            }
            return View();
        }

        [HttpGet]
        public ActionResult YazariGuncelle(int id)
        {
            var degerleriGoster = db.Tbl_Yazar.Find(id);
            return View(degerleriGoster);
        }

        [HttpPost]
        public ActionResult YazariGuncelle(Tbl_Yazar p1)
        {
            var queryGetUpdate = db.Tbl_Yazar.Find(p1.ID);
            queryGetUpdate.AD = p1.AD;
            queryGetUpdate.SOYAD = p1.SOYAD;
            queryGetUpdate.DETAY = p1.DETAY;
            db.SaveChanges();
            return RedirectToAction("IndexListe");
        }


    }
}