namespace Warsztat_programowanie_obiektowe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PartModels", "Stock", c => c.Int(nullable: false));
            AddColumn("dbo.PartModels", "ID_dealer", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PartModels", "ID_dealer");
            DropColumn("dbo.PartModels", "Stock");
        }
    }
}
