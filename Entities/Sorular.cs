using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Sorular
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SoruId { get; set; }
        [ForeignKey("OnlineIcerik")]
        public int OnlineIcerikId { get; set; }
        public string Sorular1 { get; set; }

        public virtual CoktanSecmeliSorular CoktanSecmeliSorular { get; set; }
        public virtual DogruYanlisSorular DogruYanlisSorular { get; set; }
        public virtual OnlineIcerik OnlineIcerik { get; set; }

    }
}
