namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seansaciklama : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OnlineIceriks", "SeansAciklama", c => c.String());
            DropColumn("dbo.OnlineIceriks", "SeansAdi");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OnlineIceriks", "SeansAdi", c => c.String());
            DropColumn("dbo.OnlineIceriks", "SeansAciklama");
        }
    }
}
