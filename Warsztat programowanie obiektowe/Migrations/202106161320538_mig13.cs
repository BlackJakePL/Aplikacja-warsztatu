namespace Warsztat_programowanie_obiektowe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MendingModels", "MendingState", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MendingModels", "MendingState");
        }
    }
}
