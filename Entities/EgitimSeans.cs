using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class EgitimSeans
    {
        public EgitimSeans()
        {
            this.KisiSeans = new HashSet<KisiSeans>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EgitimSeansId { get; set; }
        [ForeignKey("Dersler")]
        public int DersId { get; set; }
        public string Katilimcilar { get; set; }
       
      
        public System.DateTime HedefTarihi { get; set; }
        public System.DateTime BitisTarihi { get; set; }

        public virtual Dersler Dersler { get; set; }
     

        public virtual ICollection<KisiSeans> KisiSeans { get; set; }

    }
}
