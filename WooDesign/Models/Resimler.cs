//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WooDesign.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Resimler
    {
        public int ResimlerID { get; set; }
        public string Resim { get; set; }
        public int UrunId { get; set; }
        public string ResimAdi { get; set; }
        public string Aciklama { get; set; }
    
        public virtual Urunler Urunler { get; set; }
    }
}
