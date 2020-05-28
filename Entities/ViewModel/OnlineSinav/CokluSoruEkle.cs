using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModel.OnlineSinav
{
   public class CokluSoruEkle
    {

        public int SoruId { get; set; }

        public int CoktanSecmeliSorularId { get; set; }

        public int OnlineIcerikId { get; set; }

        public string Sorular1 { get; set; }

        public string Secenek1 { get; set; }

        public string Secenek2 { get; set; }
        public string Secenek3 { get; set; }
        public string Secenek4 { get; set; }

        public int Cevap { get; set; }
    }
}
