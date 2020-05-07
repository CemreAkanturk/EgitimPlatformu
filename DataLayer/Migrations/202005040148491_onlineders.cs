namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class onlineders : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OnlineIceriks", "OnlineId", "dbo.OnlineDers");
            DropIndex("dbo.OnlineDers", new[] { "OnlineId" });
            DropPrimaryKey("dbo.OnlineDers");
            AlterColumn("dbo.OnlineDers", "OnlineId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.OnlineDers", "OnlineId");
            CreateIndex("dbo.OnlineDers", "OnlineId");
            AddForeignKey("dbo.OnlineIceriks", "OnlineId", "dbo.OnlineDers", "OnlineId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OnlineIceriks", "OnlineId", "dbo.OnlineDers");
            DropIndex("dbo.OnlineDers", new[] { "OnlineId" });
            DropPrimaryKey("dbo.OnlineDers");
            AlterColumn("dbo.OnlineDers", "OnlineId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.OnlineDers", "OnlineId");
            CreateIndex("dbo.OnlineDers", "OnlineId");
            AddForeignKey("dbo.OnlineIceriks", "OnlineId", "dbo.OnlineDers", "OnlineId", cascadeDelete: true);
        }
    }
}
