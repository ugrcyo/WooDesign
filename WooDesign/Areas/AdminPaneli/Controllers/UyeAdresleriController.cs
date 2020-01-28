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
    public class UyeAdresleriController : Controller
    {
        ListManage list_mng = new ListManage();
        DeleteManage del_mng = new DeleteManage();
        UyelerManage uye_mng = new UyelerManage();
        AddManage add_mng = new AddManage();
        UpdateManage upt_mng = new UpdateManage();

        // GET: AdminPaneli/UyeAdresleri
        public ActionResult UyeAdresleriIndex()
        {
            return View();
        }
        public ActionResult UyeAdresleriListesi(int? sayfaNo)
        {
            int numara = sayfaNo ?? 1;
            var liste = list_mng.UyeAdresleriListesi().ToPagedList(numara, 10);
            return View(liste);
        }
        public ActionResult UyeAdresDetay(int detayId)
        {
            var detay = list_mng.UyeAdresleriListesi().FirstOrDefault(k => k.UyeAdresleriID == detayId);
            return View(detay);
        }
        public ActionResult uyeadresSil(int silId)
        {
            return View(list_mng.UyeAdresleriListesi().FirstOrDefault(k => k.UyeAdresleriID == silId));
        }

        [HttpPost, ActionName("uyeadresSil")]
        public ActionResult uyeadresDelete(int silId)
        {
            string deletemsg = del_mng.uyeadressil(silId);
            if (deletemsg.Contains("Başarılı"))
            {
                return RedirectToAction("UyeAdresleriListesi");
            }
            return View();
        }
        public ActionResult UyeAdresEkle()
        {
            List<SelectListItem> UyeListesi= new List <SelectListItem> ();
            foreach (var item in uye_mng.UyeListesi())
            {
                UyeListesi.Add(new SelectListItem
                {
                    Text = item.UyeAdi+" "+item.UyeSoyadi,
                    
                    Value = item.UyelerID.ToString()
                });
            }
            ViewBag.uyeId = UyeListesi;
            return View();
        }
        [HttpPost]
        public ActionResult UyeAdresEkle(UyeAdresleri ekle)
        {
            string insertresult = add_mng.UyeAdresEkle(ekle);
            if (insertresult.Contains("Başarılı"))
            {
                return RedirectToAction("UyeAdresleriListesi");
            }
            ViewBag.sonuc = insertresult;
            return View();
        }

        public ActionResult UyeAdresGuncelle(int gncId)
        {
            List<SelectListItem> UyeListesi = new List<SelectListItem>();
            foreach (var item in uye_mng.UyeListesi())
            {
                UyeListesi.Add(new SelectListItem
                {
                    Text = item.UyeAdi + " " + item.UyeSoyadi,

                    Value = item.UyelerID.ToString()
                });
            }
            ViewBag.uyeId = UyeListesi;
            var veri = list_mng.UyeAdresleriListesi().FirstOrDefault(k => k.UyeAdresleriID == gncId);
            return View(veri);
        }
        [HttpPost]
        public ActionResult UyeAdresGuncelle(UyeAdresleri gnc)
        {
            var uptresult = upt_mng.UyeAdresGuncelle(gnc);
            return RedirectToAction("UyeAdresleriListesi");
        }
    }
}