using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModel.Kategori
{
  public class KategoriVM
    {
        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }
        public string KategoriKodu { get; set; }
        public string Aciklama { get; set; }
        public int BolumId { get; set; }
        public string BolumAdi { get; set; }

    }
}
