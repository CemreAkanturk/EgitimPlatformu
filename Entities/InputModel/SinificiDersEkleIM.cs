using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.InputModel
{
    public class SinifciDersEkleIM
    {
        public int EgitimTuru { get; set; }
        public int KategoriId { get; set; }
        public string DersAdi { get; set; }
        public string DersKodu { get; set; }
        public string Aciklama { get; set; }
        public string EgitimSorumlusu { get; set; }
        public string HedefKitle { get; set; }
        public int Seans { get; set; }
        public int SeansPeriyodu { get; set; }  
        public string DersAfis { get; set; }
        public int DersId { get; set; }
        public int SinifIciId { get; set; }
        public int EgitmenId { get; set; }

    }
}
