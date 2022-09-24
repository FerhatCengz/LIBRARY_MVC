using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcKutuphane.Models.Siniflarim
{
    public static class UserControl
    {
        public static string UserInfo()
        {
            string newDeger = "Admin";
            string userInfo = HttpContext.Current.User.Identity.Name.ToString();
            var kontrol = userInfo.Contains("@");
            if (kontrol) // Öğrenci Girmiştir
            {
                newDeger = "Ogrenci";
                return newDeger;
            }
            return newDeger;
        }
    }
}

