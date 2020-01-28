using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WooDesign.Areas.AdminPaneli.Models;
using WooDesign.Models;
using PagedList;
using PagedList.Mvc;

namespace WooDesign.Areas.AdminPaneli.Controllers
{
    public class OdemelerController : Controller
    {
        ListManage list_mng = new ListManage();
        DeleteManage del_mng = new DeleteManage();
        AddManage add_mng = new AddManage();
        UpdateManage upt_mng = new UpdateManage();
        // GET: AdminPaneli/Odemeler
        public ActionResult OdemelerIndex()
        {
            return View();
        }
        public ActionResult OdemelerListesi(int? sayfaNo)
        {
            int numara = sayfaNo ?? 1;
            var liste = list_mng.OdemeListesi().ToPagedList(numara, 10);
            return View(liste);
        }
        public ActionResult OdemelerDetay(int detayId)
        {
            var detay = list_mng.OdemeListesi().FirstOrDefault(k => k.OdemelerID==detayId);
            return View(detay);
        }
        public ActionResult OdemeSil(int silId)
        {
            return View(list_mng.OdemeListesi().FirstOrDefault(k=>k.OdemelerID==silId));
        }

        [HttpPost,ActionName("OdemeSil")]
        public ActionResult OdemeDelete(int silId)
        {
            string deletemsg = del_mng.odemeSil(silId);
            if (deletemsg.Contains("Başarılı"))
            {
                return RedirectToAction("OdemelerListesi");
            }
            return View();
        }
        public ActionResult OdemeEkle()
        {
            List<SelectListItem> SiparisListesi = new List<SelectListItem>();
            foreach (var item in list_mng.SiparisListesi())
            {
                SiparisListesi.Add(new SelectListItem
                {
                    Text = item.SiparislerID.ToString(),
                    Value = item.SiparislerID.ToString()
                });
            }
            ViewBag.SiparisID = SiparisListesi;
            return View();
            
        }
        [HttpPost]
        public ActionResult OdemeEkle(Odemeler k)
        {
            string insertResult = add_mng.OdemeEkle(k);
            if (insertResult.Contains("Başarılı"))
            {
                return RedirectToAction("OdemelerListesi");
            }
            ViewBag.sonuc = insertResult;
            return View();
        }
        public ActionResult OdemeGuncelle(int gncId)
        {
            List<SelectListItem> SiparisListesi = new List<SelectListItem>();
            foreach (var item in list_mng.SiparisListesi())
            {
                SiparisListesi.Add(new SelectListItem
                {
                    Text = item.SiparislerID.ToString(),
                    Value = item.SiparislerID.ToString()
                });
            }
            ViewBag.SiparisID = SiparisListesi;
            var uptresult = list_mng.OdemeListesi().FirstOrDefault(k => k.OdemelerID == gncId);
           return View(uptresult);
        }
        [HttpPost]
        public ActionResult OdemeGuncelle(Odemeler gnc)
        {
            var uptresult = upt_mng.OdemeGuncelle(gnc);
            return RedirectToAction("OdemelerListesi");
        }


    }
}