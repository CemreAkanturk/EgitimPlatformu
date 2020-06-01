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
        [ForeignKey("Seans")]
        public int SinificiIcerikId { get; set; }
        public System.DateTime Tarih { get; set; }
        public string Adres { get; set; }

        public virtual SinifIciIcerik Seans { get; set; }

        public virtual ICollection<KisiSeans> KisiSeans { get; set; }

    }
}
