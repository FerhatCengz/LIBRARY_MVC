using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using MvcKutuphane.Models.Siniflarim;
namespace MvcKutuphane.Controllers
{

    public class KitapController : Controller
    {
        public void selectItemGetir()
        {
            List<SelectListItem> kategoriyiGetir = (from x in db.Tbl_Kategori.ToList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.AD,
                                                        Value = x.ID.ToString()
                                                    }).ToList();

            List<SelectListItem> yazarGetir = (from x in db.Tbl_Yazar.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.AD + " " + x.SOYAD,
                                                   Value = x.ID.ToString()

                                               }).ToList();

            ViewBag.kategoriDropDown = kategoriyiGetir;
            ViewBag.yazarGetir = yazarGetir;
        }


        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Kitap
        public ActionResult KitapList(string adi)
        {
            //var queryFrom = (from x in db.Tbl_Kitap where x.AD.Contains(adi) select x).ToList();
            var getQuery = adi == null ? db.Tbl_Kitap : db.Tbl_Kitap.Where(x => x.AD.Contains(adi));
            return View(getQuery.Where(x => x.DURUM != false).ToList());
        }

        [HttpGet]
        public ActionResult KitapEkle()
        {
            selectItemGetir();

            return View();
        }

        [HttpPost]
        public ActionResult KitapEkle(Tbl_Kitap p1)
        {
            //var ktgr = db.Tbl_Kategori.Where(x => x.ID == p1.Tbl_Kategori.ID).FirstOrDefault();
            //var yazar = db.Tbl_Yazar.Where(y => y.ID == p1.Tbl_Yazar.ID).FirstOrDefault();
            p1.KATEGORI = 1;
            p1.DURUM = true;
            var ekle = db.Tbl_Kitap.Add(p1);
            db.SaveChanges();
            return RedirectToAction("KitapList");

        }

        public ActionResult KitapSil(int id = 0)
        {

            TRYCATHPROCESS tr = new TRYCATHPROCESS();
            tr.tryIslemleri(id, db.Tbl_Kitap);
            db.SaveChanges();
            return RedirectToAction("KitapList");

        }

        [HttpGet]
        public ActionResult KitapGuncelle(int id = 0)
        {

            var updateGet = db.Tbl_Kitap.Find(id);
            if (updateGet == null) return RedirectToAction("KitapList");
            selectItemGetir();
            return View(updateGet);


        }
        [HttpPost]
        public ActionResult KitapGuncelle(Tbl_Kitap p1)
        {
            var updateGet = db.Tbl_Kitap.Find(p1.ID);
            updateGet.AD = p1.AD;
            updateGet.KATEGORI = p1.KATEGORI;
            updateGet.YAZAR = p1.YAZAR;
            updateGet.BASIMYIL = p1.BASIMYIL;
            updateGet.YAYINEVI = p1.YAYINEVI;
            updateGet.SAYFASAYISI = p1.SAYFASAYISI;
            db.SaveChanges();
            return RedirectToAction("KitapList");
        }


    }
}