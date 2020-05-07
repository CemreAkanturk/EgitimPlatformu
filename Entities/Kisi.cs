using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Kisi
    {
        public Kisi()
        {
            this.KisiSeans = new HashSet<KisiSeans>();
        }
        [Key]
        public string KisiId { get; set; }
        public string KisiKimlikNo { get; set; }
        public string KisiAdi { get; set; }
        public string KisiSoyadi { get; set; }
        public System.DateTime KisiDogumTarihi { get; set; }
        public Nullable<int> KisiCinsiyet { get; set; }
        public string KisiEgitimSeviyesi { get; set; }
        [ForeignKey("Il")]
        public int IlId { get; set; }
        [ForeignKey("Firma")]
        public int FirmaId { get; set; }
        public string KisiImagePath { get; set; }
        public Nullable<int> EhliyetSinifi { get; set; }
        public string EngelDurumu { get; set; }
        public string TelefonNo { get; set; }
        [ForeignKey("Bolum")]
        public int BolumId { get; set; }
      
        public virtual Bolum Bolum { get; set; }
        public virtual Firma Firma { get; set; }
        public virtual Il Il { get; set; }
     
        public virtual ICollection<KisiSeans> KisiSeans { get; set; }

    }
}
