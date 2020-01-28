using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WooDesign.Models;
namespace WooDesign.Areas.AdminPaneli.Models
{
    public class KategoriManage
    {
        WooDesignDBEntities db = new WooDesignDBEntities();

        public List<Kategoriler> KategoriListesi()
        {
            return db.Kategoriler.ToList();
        }
    }
}