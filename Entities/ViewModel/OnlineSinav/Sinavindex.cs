using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModel.OnlineSinav
{
   public class Sinavindex : IEnumerable
    {

        public IEnumerator Enumerator { get; set; }

        public IEnumerator GetEnumerator()
        {
            return Enumerator;
        }

        public string Dersİsim { get; set; }

        public List<Seanslar> seanslar { get; set; }

     
    }

    public class Seanslar
    {
   
        public string SeansAdi { get; set; }

        public int Seansid { get; set; }

    }
}
