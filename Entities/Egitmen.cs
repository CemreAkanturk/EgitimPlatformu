using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class Egitmen
    {
        public Egitmen()
        {
            this.Dersler = new HashSet<Dersler>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EgitmenId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public System.DateTime DogumTarih { get; set; }
        public string Resim { get; set; }
       
        [ForeignKey("Il")]
        public int IlId { get; set; }
        public string UzmanlikAlani { get; set; }
        public string EgitmenAciklama { get; set; }

     
        public virtual ICollection<Dersler> Dersler { get; set; }
        public virtual Il Il { get; set; }

    }
}
