using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SinifIciIcerik
    {

        public SinifIciIcerik()
        {
            this.EgitimSeans = new HashSet<EgitimSeans>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SinifIciIcerikId { get; set; }
        [ForeignKey("SinifIciDers")]
        public int SinifIciId { get; set; }
        public string OgrenimHedefleri { get; set; }
        public int Sure { get; set; }
        public string OrtamGereklilikleri { get; set; }
        public string EgitmenMedya { get; set; }

        public virtual SinifIciDers SinifIciDers { get; set; }

        public virtual ICollection<EgitimSeans> EgitimSeans { get; set; }
    }
}
