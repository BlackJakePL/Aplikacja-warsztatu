namespace Warsztat_programowanie_obiektowe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AdressModels", "WorkersModel_ID_worker", "dbo.WorkersModels");
            DropIndex("dbo.AdressModels", new[] { "WorkersModel_ID_worker" });
            AddColumn("dbo.WorkersModels", "ID_adress", c => c.Int(nullable: false));
            DropColumn("dbo.AdressModels", "WorkersModel_ID_worker");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AdressModels", "WorkersModel_ID_worker", c => c.Int());
            DropColumn("dbo.WorkersModels", "ID_adress");
            CreateIndex("dbo.AdressModels", "WorkersModel_ID_worker");
            AddForeignKey("dbo.AdressModels", "WorkersModel_ID_worker", "dbo.WorkersModels", "ID_worker");
        }
    }
}
