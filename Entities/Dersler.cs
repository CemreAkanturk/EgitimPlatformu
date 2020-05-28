using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class Dersler
    {
        public Dersler()
        {
            this.EgitimSeans = new HashSet<EgitimSeans>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DersId { get; set; }

        [ForeignKey("Kategoriler")]
        public int KategoriId { get; set; }
        public string DersAdi { get; set; }
        public string DersKodu { get; set; }
        public string Aciklama { get; set; }
        public int EgitimTuru { get; set; }
        [ForeignKey("Egitmen")]
        public int? EgitmenId { get; set; }

        public string DersAfis { get; set; }

        public int? Ucret { get; set; }

        public virtual Kategoriler Kategoriler { get; set; }
      
        public virtual ICollection<EgitimSeans> EgitimSeans { get; set; }
        public virtual ICollection<Firma> firmalar { get; set; }
        public virtual OnlineDers OnlineDers { get; set; }
        public virtual SinifIciDers SinifIciDers { get; set; }
        public virtual Egitmen Egitmen { get; set; }

    }
}
