using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MvcKutuphane.Models.Entity;


namespace MvcKutuphane.Controllers
{
    public class TRYCATHPROCESS
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public void tryIslemleri(int id, DbSet gelenTablo)
        {

            try
            {
                var queryRemove = gelenTablo.Find(id);
                gelenTablo.Remove(queryRemove);

            }
            catch (Exception)
            {

            }
        }

    }
}