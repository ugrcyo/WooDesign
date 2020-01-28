using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WooDesign.Models;

namespace WooDesign.Areas.AdminPaneli.Models
{
    public class LoginManage
    {
        WooDesignDBEntities db = new WooDesignDBEntities();

        public Uyeler LoginIn(string adi,string sifre)
        {
            var sorgu = db.Uyeler.Where(k => (k.Email == adi || k.NickName == adi) && k.Sifre == sifre).FirstOrDefault();
            return sorgu;
        }
    }
}