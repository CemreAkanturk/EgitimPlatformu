using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.EntityFramework
{
   public class DataContext:DbContext
    {
        public virtual DbSet<CoktanSecmeliSorular> CoktanSecmeliSorular { get; set; }
        public virtual DbSet<Dersler> Dersler { get; set; }
        public virtual DbSet<DogruYanlisSorular> DogruYanlisSorular { get; set; }
        public virtual DbSet<EgitimSeans> EgitimSeans { get; set; }
        public virtual DbSet<Kategoriler> Kategoriler { get; set; }
        public virtual DbSet<KisiSeans> KisiSeans { get; set; }
        public virtual DbSet<OnlineIcerik> OnlineIcerik { get; set; }
        public virtual DbSet<SinifIciIcerik> SinifIciIcerik { get; set; }
        public virtual DbSet<Sorular> Sorular { get; set; }

        public virtual DbSet<Bolum> Bolum { get; set; }
        public virtual DbSet<Egitmen> Egitmen { get; set; }
        public virtual DbSet<Firma> Firma { get; set; }
        public virtual DbSet<FirmaBanka> FirmaBanka { get; set; }
        public virtual DbSet<Il> Il { get; set; }

        public virtual DbSet<Kisi> Kisi { get; set; }

        public virtual DbSet<OnlineDers> OnlineDers { get; set; }

        public virtual DbSet<SinifIciDers> SinifIciDers { get; set; }

      

    }
}
