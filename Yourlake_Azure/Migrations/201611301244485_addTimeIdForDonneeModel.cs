namespace Yourlake_Azure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTimeIdForDonneeModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Donnees", "timeID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Donnees", "timeID");
        }
    }
}
