namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Yagmur : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OnlineIceriks", "OnlineId", "dbo.OnlineDers");
            DropIndex("dbo.OnlineDers", new[] { "OnlineId" });
            DropPrimaryKey("dbo.OnlineDers");
            AddColumn("dbo.OnlineIceriks", "SeansAciklama", c => c.String());
            AddColumn("dbo.OnlineIceriks", "BasarimOlcutOrani", c => c.Int(nullable: false));
            AddColumn("dbo.OnlineIceriks", "Medya", c => c.String());
            AlterColumn("dbo.OnlineDers", "OnlineId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.OnlineDers", "OnlineId");
            CreateIndex("dbo.OnlineDers", "OnlineId");
            AddForeignKey("dbo.OnlineIceriks", "OnlineId", "dbo.OnlineDers", "OnlineId", cascadeDelete: true);
            DropColumn("dbo.OnlineDers", "Medya");
            DropColumn("dbo.OnlineDers", "BasarimOlcutleri");
            DropColumn("dbo.OnlineIceriks", "BasarimOlcutu");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OnlineIceriks", "BasarimOlcutu", c => c.Int());
            AddColumn("dbo.OnlineDers", "BasarimOlcutleri", c => c.Int());
            AddColumn("dbo.OnlineDers", "Medya", c => c.String());
            DropForeignKey("dbo.OnlineIceriks", "OnlineId", "dbo.OnlineDers");
            DropIndex("dbo.OnlineDers", new[] { "OnlineId" });
            DropPrimaryKey("dbo.OnlineDers");
            AlterColumn("dbo.OnlineDers", "OnlineId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.OnlineIceriks", "Medya");
            DropColumn("dbo.OnlineIceriks", "BasarimOlcutOrani");
            DropColumn("dbo.OnlineIceriks", "SeansAciklama");
            AddPrimaryKey("dbo.OnlineDers", "OnlineId");
            CreateIndex("dbo.OnlineDers", "OnlineId");
            AddForeignKey("dbo.OnlineIceriks", "OnlineId", "dbo.OnlineDers", "OnlineId", cascadeDelete: true);
        }
    }
}
