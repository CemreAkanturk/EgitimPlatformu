namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yagmur : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bolum", "FirmaId", "dbo.Firmas");
            DropIndex("dbo.Bolum", new[] { "FirmaId" });
            CreateTable(
                "dbo.FirmaBolums",
                c => new
                    {
                        FirmaBolumId = c.Int(nullable: false, identity: true),
                        FirmaId = c.Int(nullable: false),
                        BolumId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FirmaBolumId)
                .ForeignKey("dbo.Bolum", t => t.BolumId, cascadeDelete: true)
                .ForeignKey("dbo.Firmas", t => t.FirmaId, cascadeDelete: true)
                .Index(t => t.FirmaId)
                .Index(t => t.BolumId);
            
            AlterColumn("dbo.Bolum", "BolumAcıklama", c => c.String());
            DropColumn("dbo.Bolum", "FirmaId");
            DropColumn("dbo.Egitmen", "DerslerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Egitmen", "DerslerId", c => c.Int(nullable: false));
            AddColumn("dbo.Bolum", "FirmaId", c => c.Int(nullable: false));
            DropForeignKey("dbo.FirmaBolums", "FirmaId", "dbo.Firmas");
            DropForeignKey("dbo.FirmaBolums", "BolumId", "dbo.Bolum");
            DropIndex("dbo.FirmaBolums", new[] { "BolumId" });
            DropIndex("dbo.FirmaBolums", new[] { "FirmaId" });
            AlterColumn("dbo.Bolum", "BolumAcıklama", c => c.Binary());
            DropTable("dbo.FirmaBolums");
            CreateIndex("dbo.Bolum", "FirmaId");
            AddForeignKey("dbo.Bolum", "FirmaId", "dbo.Firmas", "FirmaId", cascadeDelete: true);
        }
    }
}
