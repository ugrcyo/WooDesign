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
    
    public partial class Yetkiler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Yetkiler()
        {
            this.Uyeler = new HashSet<Uyeler>();
        }
    
        public int YetkilerID { get; set; }
        public string YetkiAdi { get; set; }
        public int PersonelID { get; set; }
    
        public virtual Personeller Personeller { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Uyeler> Uyeler { get; set; }
    }
}
