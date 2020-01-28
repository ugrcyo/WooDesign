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
    public class ReklamController : Controller
    {
        ListManage list_mng = new ListManage();
        DeleteManage del_mng = new DeleteManage();
        AddManage add_mng = new AddManage();
        UpdateManage upt_mng = new UpdateManage();
        // GET: AdminPaneli/Reklam
        public ActionResult ReklamIndex()
        {
            return View();
        }
        public ActionResult ReklamListesi(int? sayfaNo)
        {
            int numara = sayfaNo ?? 1;
            var liste = list_mng.ReklamListesi().ToPagedList(numara, 10);
            return View(liste);
        }
        public ActionResult ReklamDetay(int detayId)
        {
            var detay = list_mng.ReklamListesi().FirstOrDefault(k => k.ReklamID == detayId);
            return View(detay);
        }
        public ActionResult reklamSil(int silId)
        {
            return View(list_mng.ReklamListesi().FirstOrDefault(k => k.ReklamID == silId));
        }

        [HttpPost,ActionName("reklamSil")]
        public ActionResult reklamDelete(int silId)
        {
            string deletemsg = del_mng.reklamsil(silId);
            if (deletemsg.Contains("Başarılı"))
            {
                return RedirectToAction("ReklamListesi");
            }
            return View();
        }

        public ActionResult ReklamEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ReklamEkle(Reklamlar k)
        {
            var insertResult = add_mng.ReklamEkle(k);
            if (insertResult.Contains("Başarılı"))
            {
                return RedirectToAction("ReklamListesi");
            }
            ViewBag.sonuc = insertResult;
            return View();
        }

        public ActionResult ReklamGuncelle(int gncID)
        {
            return View(list_mng.ReklamListesi().FirstOrDefault(k => k.ReklamID == gncID));
        }

        [HttpPost]

        public ActionResult ReklamGuncelle(Reklamlar gnc)
        {
            var uptresult = upt_mng.ReklamGuncelle(gnc);

            return RedirectToAction("ReklamListesi");
        }


    }
}