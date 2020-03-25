using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class KisiSeans
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KisiSeansId { get; set; }
        [ForeignKey("Kisi")]
        public string KisiId { get; set; }
        [ForeignKey("EgitimSeans")]
        public int EgitimSeansid { get; set; }

        public virtual EgitimSeans EgitimSeans { get; set; }
        public virtual Kisi Kisi { get; set; }
    }
}
