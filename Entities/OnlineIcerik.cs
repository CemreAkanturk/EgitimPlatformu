using System;
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
     
        public OnlineIcerik()
        {
            this.Sorular = new HashSet<Sorular>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OnlineIcerikId { get; set; }
        [ForeignKey("OnlineDers")]
        public int OnlineId { get; set; }
        public int SoruSayisi { get; set; }
        public string CevapTipi { get; set; }
        public Nullable<int> BasarimOlcutu { get; set; }

        public virtual OnlineDers OnlineDers { get; set; }
      
        public virtual ICollection<Sorular> Sorular { get; set; }
    }
}
