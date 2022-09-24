using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        [HttpGet]
        public ActionResult KategoriIndex()
        {
            var degerler = db.Tbl_Kategori.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult KategoriEkle(string id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Tbl_Kategori p1)
        {

            db.Tbl_Kategori.Add(p1);
            db.SaveChanges();

            return RedirectToAction("KategoriIndex");
        }

        public ActionResult KategoriSil(int id)
        {
            var search = db.Tbl_Kategori.Find(id);
            db.Tbl_Kategori.Remove(search);
            db.SaveChanges();
            return RedirectToAction("KategoriIndex");
        }

        [HttpGet]
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.Tbl_Kategori.Find(id);
            return View("KategoriGetir", ktgr);
        }

        [HttpPost]

        public ActionResult KategoriGetir(Tbl_Kategori p1)
        {
            var searchQuery = db.Tbl_Kategori.Find(p1.ID);
            searchQuery.AD = p1.AD;
            db.SaveChanges();
            return RedirectToAction("KategoriIndex");
        }
    }
}