using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class OnlineSeans
    {


        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OnlineSeansId { get; set; }
        [ForeignKey("Kisi")]
        public string KisiId { get; set; }
        [ForeignKey("OnlineIcerik")]
        public int OnlineIcerikId { get; set; }

        public string BaşarıDurumu { get; set; }

        public virtual OnlineIcerik OnlineIcerik { get; set; }
        public virtual Kisi Kisi { get; set; }
    }
}
