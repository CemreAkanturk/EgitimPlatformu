using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModel.OnlineSinav
{
   public class Sinavindex
    {
       
        public List<string> Dersİsimleri { get; set; }

        public List<Seanslar> seanslar { get; set; }

    }

    public class Seanslar
    {
        public string DersAdi { get; set; }

        public string SeansAdi { get; set; }

        public int Seansid { get; set; }

    }
}
