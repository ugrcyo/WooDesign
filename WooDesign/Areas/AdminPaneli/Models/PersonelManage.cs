using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WooDesign.Models;
namespace WooDesign.Areas.AdminPaneli.Models
{
    public class PersonelManage
    {
        WooDesignDBEntities db = new WooDesignDBEntities();

        public List<Personeller> PersonelListesi()
        {
            return db.Personeller.ToList();
        }

        public List<Personeller> PersonelListesi(PersonelPartial nesne)
        {
            return db.Personeller.Where(k=>(string.IsNullOrEmpty(nesne.Adi) || k.Adi.Contains(nesne.Adi)) && (string.IsNullOrEmpty(nesne.Soyadi)  || k.Soyadi.Contains(nesne.Soyadi))).ToList();
        }


    }
    public partial class PersonelPartial:Personeller
    {
        public int? SayfaNo { get; set; }

        public IPagedList<Personeller>Personel_Listesi { get; set; }
    }
}