using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModel
{
    public class OnlineSeansEkle
    {
        public int OnlineIcerikId { get; set; }

        public List<Entities.OnlineIcerik> onlineicerik { get; set; }
    }
}
