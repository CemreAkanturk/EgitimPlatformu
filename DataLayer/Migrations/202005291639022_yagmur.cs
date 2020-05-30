namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yagmur : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.CoktanSecmeliSorulars", new[] { "CoktanSecmeliSorularId" });
            DropIndex("dbo.DogruYanlisSorulars", new[] { "DogruYanlisSorularId" });
            DropPrimaryKey("dbo.CoktanSecmeliSorulars");
            DropPrimaryKey("dbo.DogruYanlisSorulars");
            CreateTable(
                "dbo.DerslerFirmas",
                c => new
                    {
                        Dersler_DersId = c.Int(nullable: false),
                        Firma_FirmaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Dersler_DersId, t.Firma_FirmaId })
                .ForeignKey("dbo.Derslers", t => t.Dersler_DersId, cascadeDelete: true)
                .ForeignKey("dbo.Firmas", t => t.Firma_FirmaId, cascadeDelete: true)
                .Index(t => t.Dersler_DersId)
                .Index(t => t.Firma_FirmaId);
            
            AddColumn("dbo.Derslers", "Ucret", c => c.Int());
            AlterColumn("dbo.CoktanSecmeliSorulars", "CoktanSecmeliSorularId", c => c.Int(nullable: false));
            AlterColumn("dbo.DogruYanlisSorulars", "DogruYanlisSorularId", c => c.Int(nullable: false));
            AlterColumn("dbo.DogruYanlisSorulars", "DogruSecenek", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.CoktanSecmeliSorulars", "CoktanSecmeliSorularId");
            AddPrimaryKey("dbo.DogruYanlisSorulars", "DogruYanlisSorularId");
            CreateIndex("dbo.CoktanSecmeliSorulars", "CoktanSecmeliSorularId");
            CreateIndex("dbo.DogruYanlisSorulars", "DogruYanlisSorularId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DerslerFirmas", "Firma_FirmaId", "dbo.Firmas");
            DropForeignKey("dbo.DerslerFirmas", "Dersler_DersId", "dbo.Derslers");
            DropIndex("dbo.DerslerFirmas", new[] { "Firma_FirmaId" });
            DropIndex("dbo.DerslerFirmas", new[] { "Dersler_DersId" });
            DropIndex("dbo.DogruYanlisSorulars", new[] { "DogruYanlisSorularId" });
            DropIndex("dbo.CoktanSecmeliSorulars", new[] { "CoktanSecmeliSorularId" });
            DropPrimaryKey("dbo.DogruYanlisSorulars");
            DropPrimaryKey("dbo.CoktanSecmeliSorulars");
            AlterColumn("dbo.DogruYanlisSorulars", "DogruSecenek", c => c.Boolean(nullable: false));
            AlterColumn("dbo.DogruYanlisSorulars", "DogruYanlisSorularId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.CoktanSecmeliSorulars", "CoktanSecmeliSorularId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Derslers", "Ucret");
            DropTable("dbo.DerslerFirmas");
            AddPrimaryKey("dbo.DogruYanlisSorulars", "DogruYanlisSorularId");
            AddPrimaryKey("dbo.CoktanSecmeliSorulars", "CoktanSecmeliSorularId");
            CreateIndex("dbo.DogruYanlisSorulars", "DogruYanlisSorularId");
            CreateIndex("dbo.CoktanSecmeliSorulars", "CoktanSecmeliSorularId");
        }
    }
}
