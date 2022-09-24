using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MvcKutuphane.Models.Entity;
namespace MvcKutuphane.Controllers
{
    public class IslemlerController : Controller
    {
        // GET: IslemlerDefault
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult IslemlerIndex()
        {
            return View(db.Tbl_Hareket.Where(x => x.ISLEMDURUM == false).ToList());
        }
    }
}