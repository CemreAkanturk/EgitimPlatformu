using Entities.ViewModel.Kategori;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Entities.ViewModel.Kategori
{
    public class KategoriIndexVM
    {
       public KategoriIndexVM()
        {
             Kategoriler = new List<Entities.Kategoriler>();
             Bolumler = new List<System.Web.Mvc.SelectListItem>();
            
        }

        public List<Entities.Kategoriler> Kategoriler { get; set; }
        public List<System.Web.Mvc.SelectListItem> Bolumler { get; set; }

    }
}
