using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.InputModel
{
   public class OnlineDersEkleIM
    {
        public int DersId { get; set; }
        public int EgitimTuru { get; set; }
        public int KategoriId { get; set; }
        public string DersAdi { get; set; }
        public string DersKodu { get; set; }
        public string Aciklama { get; set; }
        public int EgitmenId { get; set; }
        public string DersAfis { get; set; }

        public int OnlineId { get; set; }
        public string OgrenimHedefleri { get; set; }
        public string OrtamGereklilikleri { get; set; }
        public string Medya { get; set; }
        public int BasarımOlcutleri { get; set; }
        public int Sure { get; set; }

    }
}
