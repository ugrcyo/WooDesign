using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WooDesign.Models;
using WooDesign.Areas.AdminPaneli.Models;
using PagedList.Mvc;
using PagedList;

namespace WooDesign.Areas.AdminPaneli.Controllers
{
    public class UrunFiyatlariController : Controller
    {
        ListManage list_mng = new ListManage();
        DeleteManage del_mng = new DeleteManage();
        AddManage add_mng = new AddManage();
        UrunlerManage urun_mng = new UrunlerManage();
        UpdateManage upt_mng = new UpdateManage();
        // GET: AdminPaneli/Yetkiler
        public ActionResult UrunFiyatlariIndex()
        {
            return View();
        }
        public ActionResult UrunFiyatlariListesi(int? sayfaNo)
        {
            int numara = sayfaNo ?? 1;
            var liste = list_mng.UrunFiyatlariListesi().ToPagedList(numara, 10);
            return View(liste);
        }
        public ActionResult UrunFiyatlariDetay(int detayId)
        {
            var detay = list_mng.UrunFiyatlariListesi().FirstOrDefault(k => k.UrunFiyatlariID == detayId);
            return View(detay);
        }
        public ActionResult urunfiyatSil(int silId)
        {
            return View(list_mng.UrunFiyatlariListesi().FirstOrDefault(k=>k.UrunFiyatlariID==silId));
        }
        
        [HttpPost,ActionName("urunfiyatSil")]
        public ActionResult urunfiyatDelete(int silId)
        {
            string deletemsg = del_mng.urunfiyatsil(silId);
            if (deletemsg.Contains("Başarılı"))
            {
                return RedirectToAction("UrunFiyatlariListesi");
            }
            return View();
        }

        public ActionResult UrunFiyatEkle()
        {
            List<SelectListItem> UrunList = new List<SelectListItem>();
            foreach (var item in urun_mng.UrunListesi())
            {
                UrunList.Add(new SelectListItem
                {
                    Text = item.UrunAdi,//Adi
                    Value = item.UrunlerID.ToString()//ID değerini alır
                });
            }
            ViewBag.UrunID = UrunList;
            return View();
        }

        [HttpPost]
        public ActionResult UrunFiyatEkle(UrunFiyatlari urun)
        {
            string insertresult = add_mng.UrunFiyatEkle(urun);
            if (insertresult.Contains("Başarılı"))
            {
                return RedirectToAction("UrunFiyatlariListesi");
            }
            ViewBag.sonuc = insertresult;
            return View();
        }

        public ActionResult UrunFiyatGuncelle(int gncId)
        {
            List<SelectListItem> UrunList = new List<SelectListItem>();
            foreach (var item in urun_mng.UrunListesi())
            {
                UrunList.Add(new SelectListItem
                {
                    Text = item.UrunAdi,
                    Value = item.UrunlerID.ToString()
                });
            }
            ViewBag.UrunID = UrunList;
            var veri = list_mng.UrunFiyatlariListesi().FirstOrDefault(k => k.UrunFiyatlariID == gncId);
            return View(veri);
        }

        [HttpPost]

        public ActionResult UrunFiyatGuncelle(UrunFiyatlari gnc)
        {
            var uptresult = upt_mng.UrunFiyatGuncelle(gnc);
            return RedirectToAction("UrunFiyatlariListesi");
        }


    }
}