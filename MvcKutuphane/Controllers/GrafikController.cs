using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MvcKutuphane.Models;
using MvcKutuphane.Models.Entity;
namespace MvcKutuphane.Controllers
{
    public class GrafikController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GoogleChart()
        {
            return Json(GrafikGetir());
        }


        public List<GoogleChartTrial> GrafikGetir()
        {
            List<GoogleChartTrial> chartTrials = new List<GoogleChartTrial>();
            var query = (from kitap in db.Tbl_Kitap select new { yayinEviAdi = kitap.YAYINEVI, sayi = db.Tbl_Kitap.Count() }).GroupBy(x => x.yayinEviAdi).ToList();
            for (int i = 0; i < query.Count; i++)
            {
                chartTrials.Add(new GoogleChartTrial
                {
                    YayinEviAdi = query[i].Key,
                    Sayi = query[i].Count()

                });
            }

            //chartTrials.Add(new GoogleChartTrial
            //{
            //    YayinEviAdi = "Mars",
            //    Sayi = 4,
            //});
            //chartTrials.Add(new GoogleChartTrial
            //{
            //    YayinEviAdi = "Yıldız",
            //    Sayi = 12,
            //});
            //chartTrials.Add(new GoogleChartTrial
            //{
            //    YayinEviAdi = "KuzuKeri",
            //    Sayi = 24,
            //});

            return chartTrials;
        }
    }
}