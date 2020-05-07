using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SinifIciDers
    {
        public SinifIciDers()
        {
            this.SinifIciIcerik = new HashSet<SinifIciIcerik>();
        }
        [Key,ForeignKey("Dersler")] 
        public int SinifIciId { get; set; }
        public string EgitimSorumlusu { get; set; }
        public string HedefKitle { get; set; }
        public int Seans { get; set; }
        public int SeansPeriyodu { get; set; }

        public virtual Dersler Dersler { get; set; }
       
        public virtual ICollection<SinifIciIcerik> SinifIciIcerik { get; set; }

    }
}
