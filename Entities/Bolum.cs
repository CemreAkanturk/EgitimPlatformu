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
   
        public string BolumKodu { get; set; }
        public string BolumAcıklama { get; set; }


        public virtual ICollection<FirmaBolum> FirmaBolums { get; set; }
        public virtual ICollection<Kisi> Kisi { get; set; }
        public virtual ICollection<Kategoriler> Kategoriler { get; set; }

    }
}
