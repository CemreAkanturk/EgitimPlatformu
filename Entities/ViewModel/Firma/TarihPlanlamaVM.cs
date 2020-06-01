using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModel.Firma
{
   public class TarihPlanlamaVM
    {
        public IEnumerator Enumerator { get; set; }

        public IEnumerator GetEnumerator()
        {
            return Enumerator;
        }
        public string DersAdi { get; set; }

        public string EgitmenAdi { get; set; }

        public List<SinifIciIcerik> seanslar { get; set; }

        public int SeansSayisi { get; set; }
    }
}
