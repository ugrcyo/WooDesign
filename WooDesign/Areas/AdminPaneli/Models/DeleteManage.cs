using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WooDesign.Models;

namespace WooDesign.Areas.AdminPaneli.Models
{
    public class DeleteManage
    {
        WooDesignDBEntities db = new WooDesignDBEntities();

        public string indirimSil(int indirimId)
        {
            try
            {
                var silinecekId = db.indirimler.FirstOrDefault(k => k.indirimlerID == indirimId);
                db.indirimler.Remove(silinecekId);
                if (db.SaveChanges() > 0)
                {

                    return "Başarılı";
                }
                return "Silme işlemi Başarısız";
            }
            catch (Exception rt)
            {
                return rt.Message;

            }
        }
        public string kategoriSil(int kategoriId)
        {
            try
            {
                var silinecekId = db.Kategoriler.FirstOrDefault(k => k.KategorilerID == kategoriId);
                db.Kategoriler.Remove(silinecekId);
                if (db.SaveChanges() > 0)
                {

                    return "Başarılı";
                }
                return "Silme işlemi Başarısız";
            }
            catch (Exception rt)
            {
                return rt.Message;

            }


        }

        public string odemeSil(int odemeId)
        {
            try
            {
                var silinecekId = db.Odemeler.FirstOrDefault(k => k.OdemelerID == odemeId);
                db.Odemeler.Remove(silinecekId);
                if (db.SaveChanges() > 0)
                {

                    return "Başarılı";
                }
                return "Silme işlemi Başarısız";
            }
            catch (Exception rt)
            {
                return rt.Message;

            }


        }
        public string personelSil(int personelId)
        {
            try
            {
                var silinecekId = db.Personeller.FirstOrDefault(k => k.PersonellerID == personelId);
                db.Personeller.Remove(silinecekId);
                if (db.SaveChanges() > 0)
                {

                    return "Başarılı";
                }
                return "Silme işlemi Başarısız";
            }
            catch (Exception rt)
            {
                return rt.Message;

            }


        }
        public string reklamsil(int reklamId)
        {
            try
            {
                var silinecekId = db.Reklamlar.FirstOrDefault(k => k.ReklamID == reklamId);
                db.Reklamlar.Remove(silinecekId);
                if (db.SaveChanges() > 0)
                {
                    return "Başarılı";
                }
                return "Silme işlemi Başarısız";
            }
            catch (Exception msg)
            {

                return msg.Message;
            }

        }
        public string urunsil(int urunId)
        {
            try
            {
                var silinecekId = db.Urunler.FirstOrDefault(k => k.UrunlerID == urunId);
                db.Urunler.Remove(silinecekId);
                if (db.SaveChanges() > 0)
                {
                    return "Başarılı";

                }
                return "Silme işlemi Başarısız";
            }
            catch (Exception msg)
            {
                return msg.Message;
            }
        }
        public string urunfiyatsil(int urunfiyatId)
        {
            try
            {
                var silinecekId = db.UrunFiyatlari.FirstOrDefault(k => k.UrunFiyatlariID == urunfiyatId);
                db.UrunFiyatlari.Remove(silinecekId);
                if (db.SaveChanges() > 0)
                {
                    return "Başarılı";
                }
                return "Silme işlemi Başarısız";
            }
            catch (Exception msg)
            {

                return msg.Message;
            }
        }
        public string urunstoksil(int urunstokId)
        {
            try
            {
                var silinecekId = db.UrunStoklari.FirstOrDefault(k => k.UrunStoklariID == urunstokId);
                db.UrunStoklari.Remove(silinecekId);
                if (db.SaveChanges()>0)
                {
                    return "Başarılı";
                }
                return "Silme işlemi Başarısız";
            }
            catch (Exception msg)
            {

                return msg.Message;
            }
        }

        public string uyeadressil(int uyeadresId)
        {
            try
            {
                var silinecekId = db.UyeAdresleri.FirstOrDefault(k => k.UyeAdresleriID == uyeadresId);
                db.UyeAdresleri.Remove(silinecekId);
                if (db.SaveChanges() > 0)
                {
                    return "Başarılı";
                }
                return "Silme işlemi Başarısız";
            }
            catch (Exception msg)
            {

                return msg.Message;
            }
        }
        public string uyesil(int uyeId)
        {
            try
            {
                var silinecekId = db.Uyeler.FirstOrDefault(k => k.UyelerID == uyeId);
                db.Uyeler.Remove(silinecekId);
                if (db.SaveChanges() > 0)
                {
                    return "Başarılı";
                }
                return "Silme işlemi Başarısız";
            }
            catch (Exception msg)
            {

                return msg.Message;
            }
        }
        public string yetkisil(int yetkiId)
        {
            try
            {
                var silinecekId = db.Yetkiler.FirstOrDefault(k => k.YetkilerID == yetkiId);
                db.Yetkiler.Remove(silinecekId);
                if (db.SaveChanges() > 0)
                {
                    return "Başarılı";
                }
                return "Silme işlemi Başarısız";
            }
            catch (Exception msg)
            {

                return msg.Message;
            }
        }
        public bool ResimSil(int resimlerId)
        {
            try
            {
                var sil = db.Resimler.FirstOrDefault(k => k.ResimlerID == resimlerId);
                db.Resimler.Remove(sil);

                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}