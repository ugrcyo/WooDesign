using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WooDesign.Models;

namespace WooDesign.Areas.AdminPaneli.Models
{
    public class ListManage
    {
        WooDesignDBEntities db = new WooDesignDBEntities();
        
       
        public List<Odemeler> OdemeListesi()
        {
            return db.Odemeler.ToList();
        }
        public List<Reklamlar> ReklamListesi()
        {
            return db.Reklamlar.ToList();
        }
        public List<UrunFiyatlari> UrunFiyatlariListesi()
        {
            return db.UrunFiyatlari.ToList();
        }
        public List<UrunStoklari> UrunStoklariListesi()
        {
            return db.UrunStoklari.ToList();
        }
        public List<UyeAdresleri> UyeAdresleriListesi()
        {           
            return db.UyeAdresleri.OrderBy(k=>k.UyeID).ToList();
        }
        public List<Yetkiler> YetkiListesi()
        {
            return db.Yetkiler.ToList();
        }
        public List<Siparisler> SiparisListesi()
        {
            return db.Siparisler.ToList();
        }
        public List<Resimler> UrununResimleri(int urunId)
        {
            return db.Resimler.Where(k => k.UrunId == urunId).ToList();
        }

    }
    
}