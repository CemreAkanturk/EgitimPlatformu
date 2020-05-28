using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModel.OnlineSinav
{
    public class CoktanSecmeliSoruVM
    {
        public int OnlineIcerikID { get; set; }
        public string soruMetin { get; set; }

        public string Secenek1 { get; set; }

        public string Secenek2 { get; set; }


        public string Secenek3 { get; set; }
        public string Secenek4 { get; set; }

        public int Cevap { get; set; }
    }
}
