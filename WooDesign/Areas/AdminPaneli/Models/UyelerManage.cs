using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WooDesign.Models;
namespace WooDesign.Areas.AdminPaneli.Models
{
    public class UyelerManage
    {
        WooDesignDBEntities db = new WooDesignDBEntities();
        public List<Uyeler> UyeListesi()
        {
            return db.Uyeler.ToList();
        }


        public List<Uyeler> UyeListesi(UyelerPartial nesne)
        {
            return db.Uyeler.Where(k=>(string.IsNullOrEmpty(nesne.UyeAdi)||k.UyeAdi.Contains(nesne.UyeAdi))&&(string.IsNullOrEmpty(nesne.UyeSoyadi) || k.UyeSoyadi.Contains(nesne.UyeSoyadi))).ToList();
        }

        
    }
    public partial class UyelerPartial : Uyeler
    {
        public int? SayfaNo { get; set; }

        public IPagedList<Uyeler> Uye_Listesi { get; set; }
    }
}