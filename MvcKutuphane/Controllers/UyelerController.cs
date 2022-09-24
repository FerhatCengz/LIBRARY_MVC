using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MvcKutuphane.Models.Entity;
using PagedList;
using PagedList.Mvc;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace MvcKutuphane.Controllers
{
    public class UyelerController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult UyeListesi(int sayfa = 1, string islem = "", int id = 0)
        {
            if (islem == "sil")
            {
                var deleteQuery = db.Tbl_Uyeler.Find(id);
                db.Tbl_Uyeler.Remove(deleteQuery);
                db.SaveChanges();
                return Json(new { response = "Başarılı" }, JsonRequestBehavior.AllowGet);
            }
            return View(db.Tbl_Uyeler.ToList().ToPagedList(sayfa, 4));
        }

        [HttpGet]
        public ActionResult YeniUye()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniUye(Tbl_Uyeler p1, string post = "json")
        {

            if (Request.Files.Count > 0)
            {

                Request.Files[0].SaveAs(Server.MapPath("/image/" + p1.MAIL + "_" + p1.USERPHOTO));
                p1.USERPHOTO = "/image/" + p1.MAIL + "_" + p1.USERPHOTO;
                db.Tbl_Uyeler.Add(p1);
                db.SaveChanges();
            }

            //Eğer Sıkıntı olursa ACİTONRESULTTU JSONA ÇEVİR
            if (post != "json")
            {
                p1.USERPHOTO = "/image/nullPerson.png";
                db.Tbl_Uyeler.Add(p1);
                db.SaveChanges();
                float uyelerLenght = db.Tbl_Uyeler.Count() / 4f;
                double dataLength = Math.Ceiling(uyelerLenght);
                if (db.Tbl_Uyeler.Count() % 4 == 0)
                {
                    dataLength++;
                }
                return RedirectToAction("UyeListesi", "Uyeler", new { sayfa = dataLength });
            }
            else
            {
                return Json(new { success = true, responseText = "Başarılı" }, JsonRequestBehavior.AllowGet);

            }
        }

        [HttpGet]
        public ActionResult UyeGuncelle(int id)
        {
            var getUpdateQuery = db.Tbl_Uyeler.Find(id);
            return View(getUpdateQuery);
        }

        [HttpPost]
        public ActionResult UyeGuncelle(Tbl_Uyeler p1)
        {
            var getUpdateQuery = db.Tbl_Uyeler.Find(p1.ID);
            getUpdateQuery.AD = p1.AD;
            getUpdateQuery.SOYAD = p1.SOYAD;
            getUpdateQuery.MAIL = p1.MAIL;
            getUpdateQuery.KAD = p1.KAD;
            getUpdateQuery.PASS = p1.PASS;
            getUpdateQuery.PHONENO = p1.PHONENO;
            getUpdateQuery.OKUL = p1.OKUL;
            db.SaveChanges();

            return RedirectToAction("UyeListesi");
        }



    }
}