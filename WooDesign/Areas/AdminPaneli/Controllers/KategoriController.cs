using PagedList;
using System.Linq;
using System.Web.Mvc;
using WooDesign.Areas.AdminPaneli.Models;
using WooDesign.Models;

namespace WooDesign.Areas.AdminPaneli.Controllers
{
    public class KategoriController : Controller
    {
        KategoriManage kat_mng = new KategoriManage();
        DeleteManage del_mng = new DeleteManage();
        AddManage add_mng = new AddManage();
        UpdateManage upt_mng = new UpdateManage();
        // GET: AdminPaneli/Kategori
        public ActionResult KategoriIndex()
        {
            return View();
        }
        public ActionResult KategoriListesi(int? sayfaNo)
        {
            int numara = sayfaNo ?? 1;
            var liste = kat_mng.KategoriListesi().ToPagedList(numara, 10);
            return View(liste);
        }
        public ActionResult KategoriDetay(int detayId)
        {
            var detay = kat_mng.KategoriListesi().FirstOrDefault(k => k.KategorilerID == detayId);
            return View(detay);
        }

        public ActionResult KategoriSil(int silId)
        {
            return View(kat_mng.KategoriListesi().FirstOrDefault(k=>k.KategorilerID==silId));
        }

        [HttpPost,ActionName("KategoriSil")]
        public ActionResult KategoriDelete(int silId)
        {
            string deletemsg = del_mng.kategoriSil(silId);
            if (deletemsg.Contains("Başarılı"))
            {
                return RedirectToAction("KategoriListesi");
            }
            return View();
        }
        public ActionResult kategoriEkle()
        {
            ViewBag.TurListesi = kat_mng.KategoriListesi();
            return View();
        }
        [HttpPost]
        public ActionResult kategoriEkle(Kategoriler k)
        {
            string insertResult = add_mng.kategoriEkle(k);
            if (insertResult.Contains("Başarılı"))
            {
                return RedirectToAction("KategoriListesi");
            }
            ViewBag.sonuc = insertResult;
            return View();
        }
        public ActionResult KategoriGuncelle(int gncID)
        {
            return View(kat_mng.KategoriListesi().FirstOrDefault(k => k.KategorilerID == gncID));
        }

        [HttpPost]

        public ActionResult KategoriGuncelle(Kategoriler gnc)
        {
            var uptresult = upt_mng.KategoriGuncelle(gnc);

            return RedirectToAction("KategoriListesi");
        }
    }
}