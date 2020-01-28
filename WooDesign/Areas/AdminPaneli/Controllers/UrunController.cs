using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WooDesign.Areas.AdminPaneli.Models;
using WooDesign.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;
using System.Configuration;
using System.Net;

namespace WooDesign.Areas.AdminPaneli.Controllers
{
    public class UrunController : Controller
    {
        WooDesignDBEntities db = new WooDesignDBEntities();
        UrunlerManage urun_mng = new UrunlerManage();
        DeleteManage del_mng = new DeleteManage();
        AddManage add_mng = new AddManage();
        UpdateManage upt_mng = new UpdateManage();
        KategoriManage kat_mng = new KategoriManage();
        ListManage list_mng = new ListManage();
        // GET: AdminPaneli/Urun
        public ActionResult UrunIndex()
        {
            return View();
        }
        public ActionResult UrunListesi(UrunPartial nesne)
        {
            int numara = nesne.sayfaNo ?? 1;

           nesne.Urun_Listesi = urun_mng.UrunListesi(nesne).ToPagedList(numara, 10);
            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Areas/AdminPaneli/Views/Urun/_PartialUrunArama.cshtml", nesne);
            }
            return View(nesne);
        }
        public ActionResult UrunDetay(int detayid)
        {
            var detay = urun_mng.UrunListesi().FirstOrDefault(k => k.UrunlerID == detayid);
            return View(detay);
        }
        public ActionResult UrunSil(int silId)
        {
            return View(urun_mng.UrunListesi().FirstOrDefault(k => k.UrunlerID == silId));
        }

        [HttpPost, ActionName("UrunSil")]
        public ActionResult UrunDelete(int silId)
        {
            string deletemsg = del_mng.urunsil(silId);
            if (deletemsg.Contains("Başarılı"))
            {
                return RedirectToAction("UrunListesi");
            }
            return View();
        }   

        public ActionResult UrunEkle()
        {
            ViewBag.KategoriListesi = kat_mng.KategoriListesi();
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(Urunler urun)
        {
            string insertresult = add_mng.UrunEkle(urun);
            if (insertresult.Contains("Başarılı"))
            {
                return RedirectToAction("UrunListesi");
            }
            ViewBag.sonuc = insertresult;
            return View();
        }
        

        public ActionResult UrunGuncelle(int guncelleId)
        {
            List<SelectListItem> kategorilist = new List<SelectListItem>();
            foreach (var item in kat_mng.KategoriListesi())
            {
                kategorilist.Add(new SelectListItem
                {
                    Text = item.KategoriAdi,
                    Value = item.KategorilerID.ToString(),

                });
            }
            ViewBag.KategoriID = kategorilist;
            var veri =urun_mng.UrunListesi().FirstOrDefault(k => k.UrunlerID == guncelleId);
            return View(veri);
        }

        [HttpPost]
        public ActionResult UrunGuncelle(Urunler gnc)
        {
            var uptresult = upt_mng.UrunGuncelle(gnc);
            return RedirectToAction("UrunListesi");
        }

        #region deneme
        //[HttpPost]
        //public ActionResult ResimSayfasi(Resimler ekle,int urunresimid)
        //{


        //    if (Request.Files.Count>0)
        //    {
        //        var durum = true;
        //        foreach (string file in Request.Files)
        //        {
        //            HttpPostedFileBase httpPostedFileBase = Request.Files[file];
        //            string yol = "/Uploads" + httpPostedFileBase.FileName;
        //            try
        //            {
        //                Request.Files[file].SaveAs(Server.MapPath(yol));
        //                ekle.ResimUrl = yol;

        //                durum = true;
        //                db.Resimler.Add(ekle);
        //                db.SaveChanges();
        //            }
        //            catch (Exception)
        //            {
        //                durum = false;
        //            }
        //        }
        //        return (durum == true ? Json(new { Message = "dosya kaydedildi" }, JsonRequestBehavior.AllowGet) : Json(new { Message = "hata tekrar dene" }, JsonRequestBehavior.AllowGet));
        //    }
        //    else
        //    {
        //        var veri = urun_mng.UrunListesi().FirstOrDefault(k => k.UrunlerID == urunresimid);
        //        return View(veri);
        //    }

        //}

        #endregion

        [HttpPost]
        public ActionResult ResimYukle(int urunId, HttpPostedFileBase[] TiklananResimler)
        {
            string KlasorYap = ConfigurationManager.AppSettings["resimdosyasi"];
            string eldeedilenYol = Server.MapPath(KlasorYap);
            bool sonuc = Directory.Exists(eldeedilenYol);
            if (sonuc == false)
            {
                Directory.CreateDirectory(eldeedilenYol);
            }
         
            foreach (var item in TiklananResimler)
            {
                string uzantiAl = item.ContentType.Split('/')[1];
                string resimKodu = $"Resim-{urunId}_{ Guid.NewGuid()}.{uzantiAl}";
                string sonHali = eldeedilenYol + "/" + resimKodu;
                item.SaveAs(sonHali);
                bool ekle = add_mng.ResimEkle(urunId, resimKodu, item.FileName, null);
            }
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public ActionResult ResimSayfasi(int urunId)
        {
            return View(urun_mng.UrunListesi().FirstOrDefault(k => k.UrunlerID == urunId));
        }

        public ActionResult ResimListesi(int urunId)
        {
            var liste = list_mng.UrununResimleri(urunId);
            return PartialView("UrunResimleriPartial", liste);
        }

        public ActionResult ResimSil(int silinecekResimId)
        {
            bool deletePicture = del_mng.ResimSil(silinecekResimId);

            return View();
        }

    }
}