using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Il")]
    public class Il
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IlId { get; set; }
        public string IlAdi { get; set; }

        public virtual ICollection<Firma> Firma { get; set; }  
        public virtual ICollection<Kisi> Kisi { get; set; }
        public virtual ICollection<Egitmen> Egitmen { get; set; }
    }
}
