using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class OnlineDers
    {

        public OnlineDers()
        {
            this.OnlineIcerik = new HashSet<OnlineIcerik>();
        }
        [Key, ForeignKey("Dersler")]
        public int OnlineId { get; set; }
        public string OgrenimHedefleri { get; set; }
        public int Sure { get; set; }
        public string OrtamGereklilikleri { get; set; }
      
        public virtual Dersler Dersler { get; set; }
     
        public virtual ICollection<OnlineIcerik> OnlineIcerik { get; set; }
    }
}
