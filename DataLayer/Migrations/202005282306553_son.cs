namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class son : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Derslers", "Ucret", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Derslers", "Ucret");
        }
    }
}
