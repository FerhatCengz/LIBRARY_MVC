using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcKutuphane.Models.Entity;
namespace MvcKutuphane.Models.Siniflarim
{

    public class TrialClass
    {
        public int Sayi { get; set; }
    }

    public class VitrinVeHakkimizdaJoin
    {
        public IEnumerable<Tbl_Hakkimizda> tbl_Hakkimizdas { get; set; }
        public IEnumerable<Tbl_Kitap> tbl_Kitaps { get; set; }


    }
}