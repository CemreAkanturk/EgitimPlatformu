using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Kategoriler
    {

        public Kategoriler()
        {
            this.Dersler = new HashSet<Dersler>();
        }
        [Key]
        public int KategoriId { get; set; }
        [Required]
        [StringLength(100)]
        public string KategoriAdi { get; set; }
        [Required]
        [StringLength(50)]
        public string KategoriKodu { get; set; }
        [Required]
        [StringLength(250)]
        public string Aciklama { get; set; }
        [ForeignKey("Bolum")]
        public int BolumId { get; set; }

        public virtual ICollection<Dersler> Dersler { get; set; }
        public virtual Bolum Bolum { get; set; }

    }
}
