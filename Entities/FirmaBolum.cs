using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class FirmaBolum
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FirmaBolumId { get; set; }
        [ForeignKey("firma")]
        public int FirmaId { get; set; }
        [ForeignKey("bolum")]
        public int BolumId { get; set; }

        public virtual Firma firma { get; set; }
        public virtual Bolum bolum { get; set; }
    }
}
