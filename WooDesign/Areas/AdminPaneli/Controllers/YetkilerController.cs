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
    public class YetkilerController : Controller
    {
        ListManage list_mng = new ListManage();
        DeleteManage del_mng = new DeleteManage();
        AddManage add_mng = new AddManage();
        UpdateManage upt_mng = new UpdateManage();
        // GET: AdminPaneli/Yetkiler
        public ActionResult YekilerIndex()
        {
            return View();
        }
        public ActionResult YetkilerListesi(int? sayfaNo)
        {
            int numara = sayfaNo ?? 1;
            var liste = list_mng.YetkiListesi().ToPagedList(numara, 10);
            return View(liste);
        }
        public ActionResult YetkiDetay(int detayId)
        {
            var detay = list_mng.YetkiListesi().FirstOrDefault(k=>k.YetkilerID==detayId);
            return View(detay);
        }
        public ActionResult YetkiSil(int silId)
        {
            return View(list_mng.YetkiListesi().FirstOrDefault(k => k.YetkilerID == silId));
        }

        [HttpPost, ActionName("YetkiSil")]
        public ActionResult YetkiDelete(int silId)
        {
            string deletemsg = del_mng.yetkisil(silId);
            if (deletemsg.Contains("Başarılı"))
            {
                return RedirectToAction("YetkilerListesi");
            }
            return View();
        }
        public ActionResult YetkiEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YetkiEkle(Yetkiler ekle)
        {
            string insertresult = add_mng.YetkiEkle(ekle);
            if (insertresult.Contains("Başarılı"))
            {
                return RedirectToAction("YetkilerListesi");
            }
            ViewBag.sonuc = insertresult;
            return View();
        }
        public ActionResult YetkiGuncelle(int gncId)
        {
            return View(list_mng.YetkiListesi().FirstOrDefault(k => k.YetkilerID == gncId));
        }

        [HttpPost]
        public ActionResult YetkiGuncelle(Yetkiler gnc)
        {
            var uptresult = upt_mng.YetkiGuncelle(gnc);
            return RedirectToAction("YetkilerListesi");
        }
    }
}