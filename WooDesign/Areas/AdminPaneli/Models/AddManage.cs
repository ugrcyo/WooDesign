using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WooDesign.Models;

namespace WooDesign.Areas.AdminPaneli.Models
{
    public class AddManage
    {
        WooDesignDBEntities db = new WooDesignDBEntities();

       public string indirimEkle(indirimler insert)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(insert.indirimTurAdi))
                {                  
                    db.indirimler.Add(insert);
                    if (db.SaveChanges() > 0)
                    {
                        return "Kayit Başarılı";
                    }
                    return "Kayıt Başarısız";
                }
                return "Başarısız";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }
        public string kategoriEkle(Kategoriler insert)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(insert.KategoriAdi))
                {
                    db.Kategoriler.Add(insert);
                    if (db.SaveChanges() > 0)
                    {
                        return "Kayit Başarılı";
                    }
                    return "Kayıt Başarısız";
                }
                return "Başarısız";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }
        public string OdemeEkle(Odemeler insert)
        {
            try
            {
                db.Odemeler.Add(insert);
                if (db.SaveChanges() > 0)
                {
                    return "Kayıt Başarılı";
                }
                return "Kayıt Başarısız";
            }
            catch (Exception msg)
            {

                return msg.Message;
            }
        }

        public string PersonelEkle(Personeller insert)
        {
            try
            {
                db.Personeller.Add(insert);
                if (db.SaveChanges() > 0)
                {
                    return "Kayıt Başarılı";
                }
                return "Kayıt Başarısız";
            }
            catch (Exception msg)
            {
                return msg.Message;
                throw;
            }
        }
        public string ReklamEkle(Reklamlar R)
        {
            try
            {
                db.Reklamlar.Add(R);
                if (db.SaveChanges() > 0)
                {
                    return "Kayıt Başarılı";
                }
                return "Kayıt Başarısız";
            }
            catch (Exception msg)
            {

                return msg.Message;
            }
        }
        public string UrunEkle(Urunler ekle)
        {
            try
            {
                db.Urunler.Add(ekle);
                if (db.SaveChanges() > 0)
                {
                    return "Kayıt Başarılı";
                }
                return "Kayıt Başarısız";
            }
            catch (Exception msg)
            {

                return msg.Message;
            }
        }

        public string UrunFiyatEkle(UrunFiyatlari ekle)
        {
            try
            {
                db.UrunFiyatlari.Add(ekle);
                if (db.SaveChanges() > 0)
                {
                    return "Kayıt Başarılı";
                }
                return "Kayıt Başarısız";
            }
            catch (Exception msg)
            {

                return msg.Message;
            }
        }

        public string UrunStokEkle(UrunStoklari stok)
        {
            try
            {
                db.UrunStoklari.Add(stok);
                if (db.SaveChanges() > 0)
                {
                    return "Kayıt Başarılı";
                }
                return "Kayıt Başarısız ";
            }
            catch (Exception msg)
            {

                return msg.Message;
            }
        }
        public string UyeAdresEkle(UyeAdresleri adres)
        {
            try
            {
                db.UyeAdresleri.Add(adres);
                if (db.SaveChanges() > 0)
                {
                    return "Kayıt Başarılı";
                }
                return "Kayıt Başarısız";
            }
            catch (Exception msg)
            {

                return msg.Message;
            }
        }
        public string UyeEkle(Uyeler uye)
        {
            try
            {
                db.Uyeler.Add(uye);
                if (db.SaveChanges() > 0)
                {
                    return "Kayıt Başarılı";
                }
                return "Kayıt Başarısız";
            }
            catch (Exception msg)
            {

                return msg.Message;
            }
        }
        public string YetkiEkle(Yetkiler yetki)
        {
            try
            {
                db.Yetkiler.Add(yetki);
                if (db.SaveChanges() > 0)
                {
                    return "Kayıt Başarılı";
                }
                return "Kayıt Başarısız";
            }
            catch (Exception msg)
            {

                return msg.Message;
            }
        }
        public bool ResimEkle(int urunId, string resim, string resimadi, string aciklama)
        {
            try
            {
                Resimler ekle = new Resimler();
                ekle.Resim = resim;
                ekle.ResimAdi = resimadi;
                ekle.Aciklama = aciklama;
                ekle.UrunId = urunId;
                db.Resimler.Add(ekle);
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
   
