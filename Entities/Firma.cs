using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Firma
    {
        public Firma()
        {
            this.Bolum = new HashSet<Bolum>();
            this.FirmaBankaBilgileri = new HashSet<FirmaBanka>();
            this.Kisi = new HashSet<Kisi>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FirmaId { get; set; }
        public string FirmaAdi { get; set; }
        public string Adres { get; set; }
        public string PostaKodu { get; set; }
        [ForeignKey("Il")]
        public int IlId { get; set; }
        public string Tel { get; set; }
        public string Cep { get; set; }
        public string Faks { get; set; }
        public string Mail { get; set; }
        public string FirmaImagePath { get; set; }
        public string FirmaKodu { get; set; }

      
        public virtual ICollection<Bolum> Bolum { get; set; }
       
        public virtual ICollection<FirmaBanka> FirmaBankaBilgileri { get; set; }
      
        public virtual ICollection<Kisi> Kisi { get; set; }
        public virtual Il Il { get; set; }

    }
}
