using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WooDesign.Models;

namespace WooDesign.Areas.AdminPaneli.Models
{
    public class UrunlerManage
    {
        WooDesignDBEntities db = new WooDesignDBEntities();

        public List<Urunler> UrunListesi()
        {
            return db.Urunler.ToList();
        }
        public List<Urunler> UrunListesi(UrunPartial nesne)
        {
            return db.Urunler.Where(k =>k.UrunAdi.Contains(nesne.UrunAdi) || string.IsNullOrEmpty(nesne.UrunAdi)).ToList();
        }

    }
    public partial class UrunPartial : Urunler
    { 
        public int? sayfaNo { get; set; }

        public IPagedList<Urunler>Urun_Listesi { get; set; }
    }
}