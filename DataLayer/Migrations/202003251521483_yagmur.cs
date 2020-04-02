namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yagmur : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bolum",
                c => new
                    {
                        BolumId = c.Int(nullable: false, identity: true),
                        BolumAdi = c.String(),
                        FirmaId = c.Int(nullable: false),
                        BolumKodu = c.String(),
                        BolumAcıklama = c.Binary(),
                    })
                .PrimaryKey(t => t.BolumId)
                .ForeignKey("dbo.Firmas", t => t.FirmaId, cascadeDelete: true)
                .Index(t => t.FirmaId);
            
            CreateTable(
                "dbo.Firmas",
                c => new
                    {
                        FirmaId = c.Int(nullable: false, identity: true),
                        FirmaAdi = c.String(),
                        Adres = c.String(),
                        PostaKodu = c.String(),
                        IlId = c.Int(nullable: false),
                        Tel = c.String(),
                        Cep = c.String(),
                        Faks = c.String(),
                        Mail = c.String(),
                        FirmaImagePath = c.String(),
                        FirmaKodu = c.String(),
                    })
                .PrimaryKey(t => t.FirmaId)
                .ForeignKey("dbo.Il", t => t.IlId, cascadeDelete: true)
                .Index(t => t.IlId);
            
            CreateTable(
                "dbo.FirmaBankas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FirmaId = c.Int(nullable: false),
                        BankaAdi = c.String(),
                        HesapNumarasi = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Firmas", t => t.FirmaId, cascadeDelete: true)
                .Index(t => t.FirmaId);
            
            CreateTable(
                "dbo.Il",
                c => new
                    {
                        IlId = c.Int(nullable: false, identity: true),
                        IlAdi = c.String(),
                    })
                .PrimaryKey(t => t.IlId);
            
            CreateTable(
                "dbo.Egitmen",
                c => new
                    {
                        EgitmenId = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        Soyad = c.String(),
                        DogumTarih = c.DateTime(nullable: false),
                        Resim = c.String(),
                        DerslerId = c.Int(nullable: false),
                        IlId = c.Int(nullable: false),
                        UzmanlikAlani = c.String(),
                        EgitmenAciklama = c.String(),
                    })
                .PrimaryKey(t => t.EgitmenId)
                .ForeignKey("dbo.Il", t => t.IlId, cascadeDelete: true)
                .Index(t => t.IlId);
            
            CreateTable(
                "dbo.Derslers",
                c => new
                    {
                        DersId = c.Int(nullable: false, identity: true),
                        KategoriId = c.Int(nullable: false),
                        DersAdi = c.String(),
                        DersKodu = c.String(),
                        Aciklama = c.String(),
                        EgitimTuru = c.Int(nullable: false),
                        EgitmenId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DersId)
                .ForeignKey("dbo.Kategorilers", t => t.KategoriId, cascadeDelete: true)
                .ForeignKey("dbo.Egitmen", t => t.EgitmenId, cascadeDelete: true)
                .Index(t => t.KategoriId)
                .Index(t => t.EgitmenId);
            
            CreateTable(
                "dbo.EgitimSeans",
                c => new
                    {
                        EgitimSeansId = c.Int(nullable: false, identity: true),
                        DersId = c.Int(nullable: false),
                        Katilimcilar = c.String(),
                        HedefTarihi = c.DateTime(nullable: false),
                        BitisTarihi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EgitimSeansId)
                .ForeignKey("dbo.Derslers", t => t.DersId, cascadeDelete: true)
                .Index(t => t.DersId);
            
            CreateTable(
                "dbo.KisiSeans",
                c => new
                    {
                        KisiSeansId = c.Int(nullable: false, identity: true),
                        KisiId = c.String(maxLength: 128),
                        EgitimSeansid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KisiSeansId)
                .ForeignKey("dbo.EgitimSeans", t => t.EgitimSeansid, cascadeDelete: true)
                .ForeignKey("dbo.Kisis", t => t.KisiId)
                .Index(t => t.KisiId)
                .Index(t => t.EgitimSeansid);
            
            CreateTable(
                "dbo.Kisis",
                c => new
                    {
                        KisiId = c.String(nullable: false, maxLength: 128),
                        KisiKimlikNo = c.String(),
                        KisiAdi = c.String(),
                        KisiSoyadi = c.String(),
                        KisiDogumTarihi = c.DateTime(nullable: false),
                        KisiCinsiyet = c.Int(),
                        KisiEgitimSeviyesi = c.String(),
                        IlId = c.Int(nullable: false),
                        FirmaId = c.Int(nullable: false),
                        KisiImagePath = c.String(),
                        EhliyetSinifi = c.Int(),
                        EngelDurumu = c.String(),
                        TelefonNo = c.String(),
                        BolumId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KisiId)
                .ForeignKey("dbo.Bolum", t => t.BolumId, cascadeDelete: true)
                .ForeignKey("dbo.Firmas", t => t.FirmaId, cascadeDelete: false)
                .ForeignKey("dbo.Il", t => t.IlId, cascadeDelete: false)
                .Index(t => t.IlId)
                .Index(t => t.FirmaId)
                .Index(t => t.BolumId);
            
            CreateTable(
                "dbo.Kategorilers",
                c => new
                    {
                        KategoriId = c.Int(nullable: false, identity: true),
                        KategoriAdi = c.String(nullable: false, maxLength: 100),
                        KategoriKodu = c.String(nullable: false, maxLength: 50),
                        Aciklama = c.String(nullable: false, maxLength: 250),
                        BolumId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KategoriId)
                .ForeignKey("dbo.Bolum", t => t.BolumId, cascadeDelete: false)
                .Index(t => t.BolumId);
            
            CreateTable(
                "dbo.OnlineDers",
                c => new
                    {
                        OnlineId = c.Int(nullable: false, identity: true),
                        OgrenimHedefleri = c.String(),
                        Sure = c.Int(nullable: false),
                        OrtamGereklilikleri = c.String(),
                        Medya = c.String(),
                        BasarimOlcutleri = c.Int(),
                    })
                .PrimaryKey(t => t.OnlineId)
                .ForeignKey("dbo.Derslers", t => t.OnlineId)
                .Index(t => t.OnlineId);
            
            CreateTable(
                "dbo.OnlineIceriks",
                c => new
                    {
                        OnlineIcerikId = c.Int(nullable: false, identity: true),
                        OnlineId = c.Int(nullable: false),
                        SoruSayisi = c.Int(nullable: false),
                        CevapTipi = c.String(),
                        BasarimOlcutu = c.Int(),
                    })
                .PrimaryKey(t => t.OnlineIcerikId)
                .ForeignKey("dbo.OnlineDers", t => t.OnlineId, cascadeDelete: true)
                .Index(t => t.OnlineId);
            
            CreateTable(
                "dbo.Sorulars",
                c => new
                    {
                        SoruId = c.Int(nullable: false, identity: true),
                        OnlineIcerikId = c.Int(nullable: false),
                        Sorular1 = c.String(),
                    })
                .PrimaryKey(t => t.SoruId)
                .ForeignKey("dbo.OnlineIceriks", t => t.OnlineIcerikId, cascadeDelete: true)
                .Index(t => t.OnlineIcerikId);
            
            CreateTable(
                "dbo.CoktanSecmeliSorulars",
                c => new
                    {
                        CoktanSecmeliSorularId = c.Int(nullable: false, identity: true),
                        Secenek1 = c.String(),
                        Secenek2 = c.String(),
                        Secenek3 = c.String(),
                        Secenek4 = c.String(),
                        Cevap = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CoktanSecmeliSorularId)
                .ForeignKey("dbo.Sorulars", t => t.CoktanSecmeliSorularId)
                .Index(t => t.CoktanSecmeliSorularId);
            
            CreateTable(
                "dbo.DogruYanlisSorulars",
                c => new
                    {
                        DogruYanlisSorularId = c.Int(nullable: false, identity: true),
                        DogruSecenek = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DogruYanlisSorularId)
                .ForeignKey("dbo.Sorulars", t => t.DogruYanlisSorularId)
                .Index(t => t.DogruYanlisSorularId);
            
            CreateTable(
                "dbo.SinifIciDers",
                c => new
                    {
                        SinifIciId = c.Int(nullable: false, identity: true),
                        EgitimSorumlusu = c.String(),
                        HedefKitle = c.String(),
                        Seans = c.Int(nullable: false),
                        SeansPeriyodu = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SinifIciId)
                .ForeignKey("dbo.Derslers", t => t.SinifIciId)
                .Index(t => t.SinifIciId);
            
            CreateTable(
                "dbo.SinifIciIceriks",
                c => new
                    {
                        SinifIciIcerikId = c.Int(nullable: false, identity: true),
                        SinifIciId = c.Int(nullable: false),
                        OgrenimHedefleri = c.String(),
                        Sure = c.Int(nullable: false),
                        OrtamGereklilikleri = c.String(),
                        EgitmenMedya = c.String(),
                    })
                .PrimaryKey(t => t.SinifIciIcerikId)
                .ForeignKey("dbo.SinifIciDers", t => t.SinifIciId, cascadeDelete: true)
                .Index(t => t.SinifIciId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bolum", "FirmaId", "dbo.Firmas");
            DropForeignKey("dbo.Firmas", "IlId", "dbo.Il");
            DropForeignKey("dbo.Egitmen", "IlId", "dbo.Il");
            DropForeignKey("dbo.Derslers", "EgitmenId", "dbo.Egitmen");
            DropForeignKey("dbo.SinifIciIceriks", "SinifIciId", "dbo.SinifIciDers");
            DropForeignKey("dbo.SinifIciDers", "SinifIciId", "dbo.Derslers");
            DropForeignKey("dbo.Sorulars", "OnlineIcerikId", "dbo.OnlineIceriks");
            DropForeignKey("dbo.DogruYanlisSorulars", "DogruYanlisSorularId", "dbo.Sorulars");
            DropForeignKey("dbo.CoktanSecmeliSorulars", "CoktanSecmeliSorularId", "dbo.Sorulars");
            DropForeignKey("dbo.OnlineIceriks", "OnlineId", "dbo.OnlineDers");
            DropForeignKey("dbo.OnlineDers", "OnlineId", "dbo.Derslers");
            DropForeignKey("dbo.Derslers", "KategoriId", "dbo.Kategorilers");
            DropForeignKey("dbo.Kategorilers", "BolumId", "dbo.Bolum");
            DropForeignKey("dbo.KisiSeans", "KisiId", "dbo.Kisis");
            DropForeignKey("dbo.Kisis", "IlId", "dbo.Il");
            DropForeignKey("dbo.Kisis", "FirmaId", "dbo.Firmas");
            DropForeignKey("dbo.Kisis", "BolumId", "dbo.Bolum");
            DropForeignKey("dbo.KisiSeans", "EgitimSeansid", "dbo.EgitimSeans");
            DropForeignKey("dbo.EgitimSeans", "DersId", "dbo.Derslers");
            DropForeignKey("dbo.FirmaBankas", "FirmaId", "dbo.Firmas");
            DropIndex("dbo.SinifIciIceriks", new[] { "SinifIciId" });
            DropIndex("dbo.SinifIciDers", new[] { "SinifIciId" });
            DropIndex("dbo.DogruYanlisSorulars", new[] { "DogruYanlisSorularId" });
            DropIndex("dbo.CoktanSecmeliSorulars", new[] { "CoktanSecmeliSorularId" });
            DropIndex("dbo.Sorulars", new[] { "OnlineIcerikId" });
            DropIndex("dbo.OnlineIceriks", new[] { "OnlineId" });
            DropIndex("dbo.OnlineDers", new[] { "OnlineId" });
            DropIndex("dbo.Kategorilers", new[] { "BolumId" });
            DropIndex("dbo.Kisis", new[] { "BolumId" });
            DropIndex("dbo.Kisis", new[] { "FirmaId" });
            DropIndex("dbo.Kisis", new[] { "IlId" });
            DropIndex("dbo.KisiSeans", new[] { "EgitimSeansid" });
            DropIndex("dbo.KisiSeans", new[] { "KisiId" });
            DropIndex("dbo.EgitimSeans", new[] { "DersId" });
            DropIndex("dbo.Derslers", new[] { "EgitmenId" });
            DropIndex("dbo.Derslers", new[] { "KategoriId" });
            DropIndex("dbo.Egitmen", new[] { "IlId" });
            DropIndex("dbo.FirmaBankas", new[] { "FirmaId" });
            DropIndex("dbo.Firmas", new[] { "IlId" });
            DropIndex("dbo.Bolum", new[] { "FirmaId" });
            DropTable("dbo.SinifIciIceriks");
            DropTable("dbo.SinifIciDers");
            DropTable("dbo.DogruYanlisSorulars");
            DropTable("dbo.CoktanSecmeliSorulars");
            DropTable("dbo.Sorulars");
            DropTable("dbo.OnlineIceriks");
            DropTable("dbo.OnlineDers");
            DropTable("dbo.Kategorilers");
            DropTable("dbo.Kisis");
            DropTable("dbo.KisiSeans");
            DropTable("dbo.EgitimSeans");
            DropTable("dbo.Derslers");
            DropTable("dbo.Egitmen");
            DropTable("dbo.Il");
            DropTable("dbo.FirmaBankas");
            DropTable("dbo.Firmas");
            DropTable("dbo.Bolum");
        }
    }
}
