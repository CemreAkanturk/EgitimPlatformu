using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public  class CoktanSecmeliSorular
    {
        [Key,ForeignKey("Sorular"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CoktanSecmeliSorularId { get; set; }
        public string Secenek1 { get; set; }
        public string Secenek2 { get; set; }
        public string Secenek3 { get; set; }
        public string Secenek4 { get; set; }
        public int Cevap { get; set; }

        public virtual Sorular Sorular { get; set; }
    }
}
