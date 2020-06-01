namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cemre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EgitimSeans", "Tarih", c => c.DateTime(nullable: false));
            AddColumn("dbo.EgitimSeans", "Adres", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EgitimSeans", "Adres");
            DropColumn("dbo.EgitimSeans", "Tarih");
        }
    }
}
