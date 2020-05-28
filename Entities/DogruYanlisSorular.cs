using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public class DogruYanlisSorular
    {
        [Key, ForeignKey("Sorular")]
        public int DogruYanlisSorularId { get; set; }
        public int DogruSecenek { get; set; }

        public virtual Sorular Sorular { get; set; }
    }
}
