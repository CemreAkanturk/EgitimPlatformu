using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModel
{
   public class SinificiSeansBilgileri
    {

        public int SinificiİcerikId { get; set; }

        public List<Entities.SinifIciIcerik> sinificiicerik { get; set; }
      
    }
}

