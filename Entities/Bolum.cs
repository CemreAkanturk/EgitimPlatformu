using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  [Table("Bolum")]
   public class Bolum
    {
      
        public Bolum()
        {
            this.Kisi = new HashSet<Kisi>();
        }
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BolumId { get; set; }
        public string BolumAdi { get; set; }
        [ForeignKey("Firma")]
        public int FirmaId { get; set; }
        public string BolumKodu { get; set; }
        public byte[] BolumAcıklama { get; set; }

        public virtual Firma Firma { get; set; }
       
        public virtual ICollection<Kisi> Kisi { get; set; }
        public virtual ICollection<Kategoriler> Kategoriler { get; set; }

    }
}
