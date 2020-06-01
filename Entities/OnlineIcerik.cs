using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class OnlineIcerik
    {
        public IEnumerator Enumerator { get; set; }

        public IEnumerator GetEnumerator()
        {
            return Enumerator;
        }


        public OnlineIcerik()
        {
            this.Sorular = new HashSet<Sorular>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OnlineIcerikId { get; set; }
        [ForeignKey("OnlineDers")]
        public int OnlineId { get; set; }
        public string SeansAciklama { get; set; }
        public int SoruSayisi { get; set; }
        public string CevapTipi { get; set; }
        public int BasarimOlcutOrani { get; set; }
        public string Medya { get; set; }
        public virtual OnlineDers OnlineDers { get; set; }
      
        public virtual ICollection<Sorular> Sorular { get; set; }
        public virtual ICollection<OnlineSeans> OnlineSeans { get; set; }
    }
}
