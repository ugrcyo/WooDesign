using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WooDesign.Models;

namespace WooDesign.Areas.AdminPaneli.Models
{
    public class UpdateManage
    {
        WooDesignDBEntities db = new WooDesignDBEntities();

        public bool indirimGuncelle(indirimler gnc)
        {
            var upt = db.indirimler.FirstOrDefault(k => k.indirimlerID == gnc.indirimlerID);
            db.Entry(upt).CurrentValues.SetValues(gnc);
            if (db.SaveChanges()>0)
            {
                return true;
            }
            return false;
        }

        public bool KategoriGuncelle(Kategoriler gnc)
        {
            var upt = db.Kategoriler.FirstOrDefault(k => k.KategorilerID == gnc.KategorilerID);
            db.Entry(upt).CurrentValues.SetValues(gnc);
            if (db.SaveChanges()>0)
            {
                return true;
            }
            return false;
        }
        public bool OdemeGuncelle(Odemeler gnc)
        {
            var upt = db.Odemeler.FirstOrDefault(k => k.OdemelerID == gnc.OdemelerID);
            db.Entry(upt).CurrentValues.SetValues(gnc);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        public bool PersonelGuncelle(Personeller gnc)
        {
            var upt = db.Personeller.FirstOrDefault(k => k.PersonellerID == gnc.PersonellerID);
            db.Entry(upt).CurrentValues.SetValues(gnc);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        public bool ReklamGuncelle(Reklamlar gnc)
        {
            var upt = db.Reklamlar.FirstOrDefault(k => k.ReklamID == gnc.ReklamID);
            db.Entry(upt).CurrentValues.SetValues(gnc);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        public bool UrunGuncelle(Urunler gnc)
        {
            var upt = db.Urunler.FirstOrDefault(k => k.UrunlerID == gnc.UrunlerID);
            db.Entry(upt).CurrentValues.SetValues(gnc);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        public bool UrunFiyatGuncelle(UrunFiyatlari gnc)
        {
            var upt = db.UrunFiyatlari.FirstOrDefault(k => k.UrunFiyatlariID == gnc.UrunFiyatlariID);
            db.Entry(upt).CurrentValues.SetValues(gnc);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        public bool UrunStokGuncelle(UrunStoklari gnc)
        {
            var upt = db.UrunStoklari.FirstOrDefault(k => k.UrunStoklariID == gnc.UrunStoklariID);
            db.Entry(upt).CurrentValues.SetValues(gnc);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        public bool UyeAdresGuncelle(UyeAdresleri gnc)
        {
            var upt = db.UyeAdresleri.FirstOrDefault(k => k.UyeAdresleriID == gnc.UyeAdresleriID);
            db.Entry(upt).CurrentValues.SetValues(gnc);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        public bool UyeGuncelle(Uyeler gnc)
        {
            var upt = db.Uyeler.FirstOrDefault(k => k.UyelerID == gnc.UyelerID);
            db.Entry(upt).CurrentValues.SetValues(gnc);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        public bool YetkiGuncelle(Yetkiler gnc)
        {
            var upt = db.Yetkiler.FirstOrDefault(k => k.YetkilerID == gnc.YetkilerID);
            db.Entry(upt).CurrentValues.SetValues(gnc);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
    }
}