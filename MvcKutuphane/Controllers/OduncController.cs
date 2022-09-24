using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using System.Data.Entity;
namespace MvcKutuphane.Controllers
{
    [Authorize(Roles = "A")]
    public class OduncController : Controller
    {

        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult HareketLisesi()
        {
            var queryTbl = db.Tbl_Hareket.Where(x => x.ISLEMDURUM == true).ToList();
            return View(queryTbl);
        }

        public ActionResult OdunVer()
        {
            List<SelectListItem> uyeDropDown = (from x in db.Tbl_Uyeler.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.AD + " " + x.SOYAD,
                                                    Value = x.ID.ToString()
                                                }).ToList();

            ViewBag.uyeDropDown = uyeDropDown;
            return View();
        }

        [HttpPost]
        public ActionResult OdunVer(Tbl_Hareket p1)
        {
            p1.ISLEMDURUM = true;
            p1.ALISTARIHI = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p1.IADETARIHI = Convert.ToDateTime(DateTime.Now.AddDays(7).ToShortDateString());
            db.Tbl_Hareket.Add(p1);
            db.SaveChangesAsync();
            return RedirectToAction("HareketLisesi");
        }

        [HttpGet]
        public ActionResult OduncIade(int id)
        {
            var query = db.Tbl_Hareket.Find(id);
            DateTime d1 = DateTime.Parse(query.IADETARIHI.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = DateTime.Parse(d2.ToShortDateString()) - d1;


            ViewBag.d1 = d3.TotalDays;
            return View(query);
        }
        [HttpPost] // Güncelle
        public ActionResult OduncIade(Tbl_Hareket p1)
        {

            var queryUpdate = db.Tbl_Hareket.Find(p1.ID);
            queryUpdate.ISLEMDURUM = false;
            queryUpdate.UYEGETIRTARIH = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            db.SaveChangesAsync();
            return RedirectToAction("HareketLisesi");

        }

    }
}