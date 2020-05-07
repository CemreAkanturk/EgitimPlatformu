namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yagmur : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Derslers", "EgitmenId", "dbo.Egitmen");
            DropForeignKey("dbo.SinifIciIceriks", "SinifIciId", "dbo.SinifIciDers");
            DropIndex("dbo.Derslers", new[] { "EgitmenId" });
            DropIndex("dbo.SinifIciDers", new[] { "SinifIciId" });
            DropPrimaryKey("dbo.SinifIciDers");
            AddColumn("dbo.Derslers", "DersAfis", c => c.String());
            AlterColumn("dbo.Derslers", "EgitmenId", c => c.Int());
            AlterColumn("dbo.SinifIciDers", "SinifIciId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.SinifIciDers", "SinifIciId");
            CreateIndex("dbo.Derslers", "EgitmenId");
            CreateIndex("dbo.SinifIciDers", "SinifIciId");
            AddForeignKey("dbo.Derslers", "EgitmenId", "dbo.Egitmen", "EgitmenId");
            AddForeignKey("dbo.SinifIciIceriks", "SinifIciId", "dbo.SinifIciDers", "SinifIciId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SinifIciIceriks", "SinifIciId", "dbo.SinifIciDers");
            DropForeignKey("dbo.Derslers", "EgitmenId", "dbo.Egitmen");
            DropIndex("dbo.SinifIciDers", new[] { "SinifIciId" });
            DropIndex("dbo.Derslers", new[] { "EgitmenId" });
            DropPrimaryKey("dbo.SinifIciDers");
            AlterColumn("dbo.SinifIciDers", "SinifIciId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Derslers", "EgitmenId", c => c.Int(nullable: false));
            DropColumn("dbo.Derslers", "DersAfis");
            AddPrimaryKey("dbo.SinifIciDers", "SinifIciId");
            CreateIndex("dbo.SinifIciDers", "SinifIciId");
            CreateIndex("dbo.Derslers", "EgitmenId");
            AddForeignKey("dbo.SinifIciIceriks", "SinifIciId", "dbo.SinifIciDers", "SinifIciId", cascadeDelete: true);
            AddForeignKey("dbo.Derslers", "EgitmenId", "dbo.Egitmen", "EgitmenId", cascadeDelete: true);
        }
    }
}
