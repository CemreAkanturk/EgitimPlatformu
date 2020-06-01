namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cemre41 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.EgitimSeans", "Tarih");
            DropColumn("dbo.EgitimSeans", "Adres");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EgitimSeans", "Adres", c => c.String());
            AddColumn("dbo.EgitimSeans", "Tarih", c => c.DateTime(nullable: false));
        }
    }
}
