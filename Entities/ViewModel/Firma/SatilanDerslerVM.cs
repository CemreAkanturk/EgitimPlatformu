using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModel.Firma
{
   public class SatilanDerslerVM
    {
        public string DersAdi { get; set; }

        public string Aciklma { get; set; }

        public int SeansSayisi { get; set; }

        public int SorSayisi { get; set; }

        public int DersId { get; set; }
        public int? Ucret { get; set; }


    }
}
