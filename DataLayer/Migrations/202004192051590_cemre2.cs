namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cemre2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SinifIciIceriks", "SinifIciId", "dbo.SinifIciDers");
            DropIndex("dbo.SinifIciDers", new[] { "SinifIciId" });
            DropPrimaryKey("dbo.SinifIciDers");
            AlterColumn("dbo.SinifIciDers", "SinifIciId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.SinifIciDers", "SinifIciId");
            CreateIndex("dbo.SinifIciDers", "SinifIciId");
            AddForeignKey("dbo.SinifIciIceriks", "SinifIciId", "dbo.SinifIciDers", "SinifIciId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SinifIciIceriks", "SinifIciId", "dbo.SinifIciDers");
            DropIndex("dbo.SinifIciDers", new[] { "SinifIciId" });
            DropPrimaryKey("dbo.SinifIciDers");
            AlterColumn("dbo.SinifIciDers", "SinifIciId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.SinifIciDers", "SinifIciId");
            CreateIndex("dbo.SinifIciDers", "SinifIciId");
            AddForeignKey("dbo.SinifIciIceriks", "SinifIciId", "dbo.SinifIciDers", "SinifIciId", cascadeDelete: true);
        }
    }
}
