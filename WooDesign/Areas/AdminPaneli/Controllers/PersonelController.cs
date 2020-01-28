using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WooDesign.Areas.AdminPaneli.Models;
using PagedList;
using WooDesign.Models;

namespace WooDesign.Areas.AdminPaneli.Controllers
{
    public class PersonelController : Controller
    {
        PersonelManage prs_mng = new PersonelManage();
        DeleteManage del_mng = new DeleteManage();
        AddManage add_mng = new AddManage();
        ListManage list_mng = new ListManage();
        UpdateManage upt_mng = new UpdateManage();

        // GET: AdminPaneli/Personel
        public ActionResult PersonelIndex()
        {
            return View();
        }

        public ActionResult PersonelListesi(PersonelPartial nesne)
        {
            int numara = nesne.SayfaNo ?? 1;
            nesne.Personel_Listesi = prs_mng.PersonelListesi(nesne).ToPagedList(numara, 10);
            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Areas/AdminPaneli/Views/Uyeler/_PartialPersonelArama.cshtml", nesne);
            }
            return View(nesne);
        }
        public ActionResult PersonelDetay(int detayId)
        {
            var detay = prs_mng.PersonelListesi().FirstOrDefault(k => k.PersonellerID == detayId);
            return View(detay);
        }
        public ActionResult PersonelSil(int silId)
        {
            return View(prs_mng.PersonelListesi().FirstOrDefault(k => k.PersonellerID == silId));
        }

        [HttpPost, ActionName("PersonelSil")]
        public ActionResult DeletePersonel(int silId)
        {
            string deletemsg = del_mng.personelSil(silId);
            if (deletemsg.Contains("başarılı"))
            {
                return RedirectToAction("PersonelListesi");
            }
            return View();

        }

        public ActionResult PersonelEkle()
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
        public ActionResult PersonelEkle(Personeller k)
        {
            string insertresult = add_mng.PersonelEkle(k);
            if (insertresult.Contains("Başarılı"))
            {
                return RedirectToAction("PersonelListesi");
            }
            ViewBag.sonuc = insertresult;
            return View();
        }
        public ActionResult PersonelGuncelle(int guncelleId)
        {
            List<SelectListItem> yetkilist = new List<SelectListItem>();
            foreach (var item in list_mng.YetkiListesi())
            {
                yetkilist.Add(new SelectListItem
                {
                    Text = item.YetkiAdi.ToString(),
                    Value = item.YetkilerID.ToString(),
                   
                });
            }
            ViewBag.YetkiID = yetkilist;

            var veri = prs_mng.PersonelListesi().FirstOrDefault(k => k.PersonellerID == guncelleId);
            return View(veri);
        }
        [HttpPost]
        public ActionResult PersonelGuncelle(Personeller gnc)
        {
            var uptresult = upt_mng.PersonelGuncelle(gnc);
            return RedirectToAction("PersonelListesi");
        }



    }
}