//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EgitimPlatformu.Models.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kategoriler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kategoriler()
        {
            this.Dersler = new HashSet<Dersler>();
        }
    
        public int KategoriId { get; set; }
        public string Aciklama { get; set; }
        public int Bolum { get; set; }
        public string KategoriAdi { get; set; }
        public string KategoriKodu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dersler> Dersler { get; set; }
    }
}