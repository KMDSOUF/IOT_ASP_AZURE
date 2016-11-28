namespace Yourlake_Azure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Donnees",
                c => new
                    {
                        DonneeId = c.Int(nullable: false, identity: true),
                        Temperature = c.String(),
                        Debit = c.String(),
                        Humidite_eau = c.String(),
                        Humidite = c.String(),
                        Time = c.String(),
                        RegionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DonneeId)
                .ForeignKey("dbo.Regions", t => t.RegionId, cascadeDelete: true)
                .Index(t => t.RegionId);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        RegionId = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.RegionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Donnees", "RegionId", "dbo.Regions");
            DropIndex("dbo.Donnees", new[] { "RegionId" });
            DropTable("dbo.Regions");
            DropTable("dbo.Donnees");
        }
    }
}
