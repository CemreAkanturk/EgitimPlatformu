using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModel.OnlineSinav
{
    public class DySoruEkle
    {
       public int SoruId { get; set; }

       public int DogruYanlisSorularId { get; set; }
       
       public int OnlineIcerikId { get; set; }

       public string Sorular1 { get; set; }

        public int DogruSecenek { get; set; }

    }
}
