namespace Warsztat_programowanie_obiektowe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PartModels", "MendingModel_ID_mending", "dbo.MendingModels");
            DropIndex("dbo.PartModels", new[] { "MendingModel_ID_mending" });
            DropColumn("dbo.PartModels", "MendingModel_ID_mending");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PartModels", "MendingModel_ID_mending", c => c.Int());
            CreateIndex("dbo.PartModels", "MendingModel_ID_mending");
            AddForeignKey("dbo.PartModels", "MendingModel_ID_mending", "dbo.MendingModels", "ID_mending");
        }
    }
}
