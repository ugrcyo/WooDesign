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
    public class indirimlerController : Controller
    {
        IndirimlerManage ind_mng = new IndirimlerManage();
        DeleteManage del_mng = new DeleteManage();
        AddManage add_mng = new AddManage();
        UpdateManage upt_mng = new UpdateManage();
        // GET: AdminPaneli/indirimler
        public ActionResult indirimlerIndex()
        {
            return View();
        }
        public ActionResult indirimDropDownIndex()
        {
            List<SelectListItem> SanalList = new List<SelectListItem>();

            foreach (var item in ind_mng.indirimTurleriListesi())
            {
                SanalList.Add(new SelectListItem
                {
                    Text = item.indirimTurAdi,
                    Value = item.indirimTurleriID.ToString()
                });

            }
            ViewBag.indirimTurAdi = SanalList;
            return View();
        }
        public ActionResult indirimListesi(int? sayfaNo)
        {
            int numara = sayfaNo ?? 1;
            var liste = ind_mng.indirimListesi().ToPagedList(numara, 10);
            return View(liste);
        }
        public ActionResult indirimDetay(int detayId)
        {
            var detay = ind_mng.indirimListesi().FirstOrDefault(k => k.indirimlerID == detayId);
            return View(detay);
        }
        public ActionResult indirimsil(int silId)
        {
            return View(ind_mng.indirimListesi().FirstOrDefault(k=>k.indirimlerID==silId));
        }

        [HttpPost, ActionName("indirimsil")]
        public ActionResult deleteindirim(int silId)
        {
            string deletemsg = del_mng.indirimSil(silId);
            if (deletemsg.Contains("başarılı"))
            {
                return RedirectToAction("indirimListesi");
            }
            return View();
        }
        public ActionResult indirimEkle()
        {
            ViewBag.TurListesi = ind_mng.indirimTurleriListesi();
            return View();
        }
        [HttpPost]
        public ActionResult indirimEkle(indirimler k)
        {
            DateTime SonTarih = k.BitisTarihi ?? DateTime.MinValue;
            string insertResult = add_mng.indirimEkle(k);
            if (insertResult.Contains("Başarılı"))
            {
                return RedirectToAction("indirimListesi");
            }
            ViewBag.sonuc = insertResult;
            return View();
        }
        public ActionResult indirimGunceller(int gncID)
        {
            return View(ind_mng.indirimListesi().FirstOrDefault(k => k.indirimlerID == gncID));
        }

        [HttpPost]

        public ActionResult indirimGunceller(indirimler gnc)
        {
            var uptresult = upt_mng.indirimGuncelle(gnc);
            
            return RedirectToAction("indirimListesi");
        }

    }
}