namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cemre : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Egitmen", "DerslerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Egitmen", "DerslerId", c => c.Int(nullable: false));
        }
    }
}
