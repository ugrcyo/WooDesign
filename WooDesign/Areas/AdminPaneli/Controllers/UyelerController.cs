using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WooDesign.Models;
using WooDesign.Areas.AdminPaneli.Models;
using PagedList;
using PagedList.Mvc;

namespace WooDesign.Areas.AdminPaneli.Controllers
{
    public class UyelerController : Controller
    {
        UyelerManage uye_mng = new UyelerManage();
        DeleteManage del_mng = new DeleteManage();
        AddManage add_mng = new AddManage();
        ListManage list_mng = new ListManage();
        UpdateManage upt_mng = new UpdateManage(); 
        // GET: AdminPaneli/Uyeler
        public ActionResult UyelerIndex()
        {
            return View();
        }
        
        public ActionResult UyeListesi(UyelerPartial nesne )
        {
            int numara = nesne.SayfaNo ?? 1;
            nesne.Uye_Listesi=uye_mng.UyeListesi(nesne).ToPagedList(numara, 15);
            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Areas/AdminPaneli/Views/Uyeler/_PartialUyeArama.cshtml", nesne);
            }
            return View(nesne);
        }
        public ActionResult UyeDetay(int detayId)
        {
            var detay = uye_mng.UyeListesi().FirstOrDefault(k => k.UyelerID == detayId);
            return View(detay);
        }
        public ActionResult UyeSil(int silId)
        {
            return View(uye_mng.UyeListesi().FirstOrDefault(k => k.UyelerID == silId));
        }

        [HttpPost, ActionName("UyeSil")]
        public ActionResult UyeDelete(int silId)
        {
            string deletemsg = del_mng.uyesil(silId);
            if (deletemsg.Contains("Başarılı"))
            {
                return RedirectToAction("UyeListesi");
            }
            return View();
        }

        public ActionResult UyeEkle()
        {
            List<SelectListItem> YetkiListesi = new List<SelectListItem>();
            foreach (var item in list_mng.YetkiListesi())
            {
                YetkiListesi.Add(new SelectListItem
                {
                    Text = item.YetkiAdi,
                    Value = item.YetkilerID.ToString()
                });
            }
            ViewBag.YetkiID = YetkiListesi;
            return View();
        }

        [HttpPost]
        public ActionResult UyeEkle(Uyeler ekle)
        {
            string insertresult = add_mng.UyeEkle(ekle);
            if (insertresult.Contains("Başarılı"))
            {
                return RedirectToAction("UyeListesi");
            }
            ViewBag.sonuc = insertresult;
            return View();
        }

        public ActionResult UyeGuncelle(int gncId)
        {
            List<SelectListItem> YetkiListesi = new List<SelectListItem>();
            foreach (var item in list_mng.YetkiListesi())
            {
                YetkiListesi.Add(new SelectListItem
                {
                    Text = item.YetkiAdi,
                    Value = item.YetkilerID.ToString()
                });
            }
            ViewBag.YetkiID = YetkiListesi;
            var veri = uye_mng.UyeListesi().FirstOrDefault(k => k.UyelerID == gncId);
            return View(veri);
        }

        [HttpPost]
        public ActionResult UyeGuncelle(Uyeler gnc)
        {
            var insertresult = upt_mng.UyeGuncelle(gnc);
            return RedirectToAction("UyeListesi");
        }
    }
}