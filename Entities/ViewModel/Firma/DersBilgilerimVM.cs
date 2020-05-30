using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModel.Firma
{
    public class DersBilgilerimVM
    {
        public Dersler ders { get; set; }

        public Egitmen egitmen { get; set; }

        public List<Kisi> katilimcilar { get; set; }

        public int SeansSayisi { get; set; }

    
    }
}
