//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WooDesign
{
    using System;
    using System.Collections.Generic;
    
    public partial class Uyeler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Uyeler()
        {
            this.Siparisler = new HashSet<Siparisler>();
            this.UyeAdresleri = new HashSet<UyeAdresleri>();
        }
    
        public int UyelerID { get; set; }
        public string NickName { get; set; }
        public Nullable<int> YetkiID { get; set; }
        public string Sifre { get; set; }
        public string UyeAdi { get; set; }
        public string UyeSoyadi { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public System.DateTime UyeOlmaTarihi { get; set; }
        public Nullable<System.DateTime> UyeBitisTarihi { get; set; }
        public string Cinsiyet { get; set; }
        public bool Durum { get; set; }
        public string Aciklama { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Siparisler> Siparisler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UyeAdresleri> UyeAdresleri { get; set; }
        public virtual Yetkiler Yetkiler { get; set; }
    }
}
