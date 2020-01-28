using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WooDesign.Models;

namespace WooDesign.Areas.AdminPaneli.Models
{
    public class IndirimlerManage
    {
        WooDesignDBEntities db = new WooDesignDBEntities();

        public List<indirimler> indirimListesi()
        {
            return db.indirimler.ToList();
        }
        public List<indirimTurleri> indirimTurleriListesi()
        {
            return db.indirimTurleri.ToList();
        }
    }
}