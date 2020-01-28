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
    public class UrunStoklariController : Controller
    {
        ListManage list_mng = new ListManage();
        DeleteManage del_mng = new DeleteManage();
        AddManage add_mng = new AddManage();
        UpdateManage upt_mng = new UpdateManage();
        // GET: AdminPaneli/Yetkiler
        public ActionResult UrunStoklariIndex()
        {
            return View();
        }
        public ActionResult UrunStoklariListesi(int? sayfaNo)
        {
            int numara = sayfaNo ?? 1;
            var liste = list_mng.UrunStoklariListesi().ToPagedList(numara, 10);
            return View(liste);
        }
        public ActionResult UrunStoklariDetay(int detayId)
        {
            var detay = list_mng.UrunStoklariListesi().FirstOrDefault(k => k.UrunStoklariID == detayId);
            return View(detay);
        }
        public ActionResult urunstokSil(int silId)
        {
            return View(list_mng.UrunStoklariListesi().FirstOrDefault(k => k.UrunStoklariID == silId));
        }

        [HttpPost, ActionName("urunstokSil")]
        public ActionResult urunstokDelete(int silId)
        {
            string deletemsg = del_mng.urunstoksil(silId);
            if (deletemsg.Contains("Başarılı"))
            {
                return RedirectToAction("UrunStoklariListesi");
            }
            return View();
        }

        UrunlerManage urun_mng = new UrunlerManage();
        public ActionResult UrunStokEkle()
        {
            List<SelectListItem> UrunList = new List<SelectListItem>();
            foreach (var item in urun_mng.UrunListesi())
            {
                UrunList.Add(new SelectListItem
                    {
                      Text=item.UrunAdi,
                      Value=item.UrunlerID.ToString()
                    });
            }
            ViewBag.urunID = UrunList;
            return View();
        }

        [HttpPost]
        public ActionResult UrunStokEkle(UrunStoklari ekle)
        {
            string insertresult = add_mng.UrunStokEkle(ekle);
            if (insertresult.Contains("Başarılı"))
            {
                return RedirectToAction("UrunStoklariListesi");
            }
            ViewBag.sonuc = insertresult;
            return View();
        }
        public ActionResult UrunStokGuncelle(int gncId)
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
            var veri = list_mng.UrunStoklariListesi().FirstOrDefault(k => k.UrunStoklariID == gncId);
            return View(veri);
        }

        [HttpPost]

        public ActionResult UrunStokGuncelle(UrunStoklari gnc)
        {
            var uptresult = upt_mng.UrunStokGuncelle(gnc);
            return RedirectToAction("UrunStoklariListesi");
        }

    }
}