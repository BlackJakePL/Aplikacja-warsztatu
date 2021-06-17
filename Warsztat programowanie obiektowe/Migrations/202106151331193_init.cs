namespace Warsztat_programowanie_obiektowe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdressModels",
                c => new
                    {
                        ID_adress = c.Int(nullable: false, identity: true),
                        City = c.String(),
                        ZipCode = c.String(),
                        Street = c.String(),
                        BuildingNo = c.String(),
                        FlatNo = c.String(),
                        ClientModel_ID_client = c.Int(),
                        WorkersModel_ID_worker = c.Int(),
                    })
                .PrimaryKey(t => t.ID_adress)
                .ForeignKey("dbo.ClientModels", t => t.ClientModel_ID_client)
                .ForeignKey("dbo.WorkersModels", t => t.WorkersModel_ID_worker)
                .Index(t => t.ClientModel_ID_client)
                .Index(t => t.WorkersModel_ID_worker);
            
            CreateTable(
                "dbo.CarModels",
                c => new
                    {
                        VIN = c.String(nullable: false, maxLength: 128),
                        ID_client = c.String(),
                        Make = c.String(),
                        Model = c.String(),
                        Power = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        fuel = c.String(),
                        MendingModel_ID_mending = c.Int(),
                    })
                .PrimaryKey(t => t.VIN)
                .ForeignKey("dbo.MendingModels", t => t.MendingModel_ID_mending)
                .Index(t => t.MendingModel_ID_mending);
            
            CreateTable(
                "dbo.ClientModels",
                c => new
                    {
                        ID_client = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNo = c.String(),
                    })
                .PrimaryKey(t => t.ID_client);
            
            CreateTable(
                "dbo.DealerModels",
                c => new
                    {
                        ID_dealer = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PhoneNo = c.String(),
                        NIP = c.Int(nullable: false),
                        PartModel_ID_part = c.Int(),
                    })
                .PrimaryKey(t => t.ID_dealer)
                .ForeignKey("dbo.PartModels", t => t.PartModel_ID_part)
                .Index(t => t.PartModel_ID_part);
            
            CreateTable(
                "dbo.MendingListModels",
                c => new
                    {
                        ID_row = c.Int(nullable: false, identity: true),
                        ID_mending = c.Int(nullable: false),
                        ID_part = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_row);
            
            CreateTable(
                "dbo.MendingModels",
                c => new
                    {
                        ID_mending = c.Int(nullable: false, identity: true),
                        MendingDate = c.DateTime(nullable: false),
                        MendingTime = c.Single(nullable: false),
                        VIN = c.String(),
                        ID_worker = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_mending);
            
            CreateTable(
                "dbo.PartModels",
                c => new
                    {
                        ID_part = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Single(nullable: false),
                        MendingModel_ID_mending = c.Int(),
                    })
                .PrimaryKey(t => t.ID_part)
                .ForeignKey("dbo.MendingModels", t => t.MendingModel_ID_mending)
                .Index(t => t.MendingModel_ID_mending);
            
            CreateTable(
                "dbo.WorkersModels",
                c => new
                    {
                        ID_worker = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNo = c.String(),
                        MendingModel_ID_mending = c.Int(),
                    })
                .PrimaryKey(t => t.ID_worker)
                .ForeignKey("dbo.MendingModels", t => t.MendingModel_ID_mending)
                .Index(t => t.MendingModel_ID_mending);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.WorkersModels", "MendingModel_ID_mending", "dbo.MendingModels");
            DropForeignKey("dbo.AdressModels", "WorkersModel_ID_worker", "dbo.WorkersModels");
            DropForeignKey("dbo.PartModels", "MendingModel_ID_mending", "dbo.MendingModels");
            DropForeignKey("dbo.DealerModels", "PartModel_ID_part", "dbo.PartModels");
            DropForeignKey("dbo.CarModels", "MendingModel_ID_mending", "dbo.MendingModels");
            DropForeignKey("dbo.AdressModels", "ClientModel_ID_client", "dbo.ClientModels");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.WorkersModels", new[] { "MendingModel_ID_mending" });
            DropIndex("dbo.PartModels", new[] { "MendingModel_ID_mending" });
            DropIndex("dbo.DealerModels", new[] { "PartModel_ID_part" });
            DropIndex("dbo.CarModels", new[] { "MendingModel_ID_mending" });
            DropIndex("dbo.AdressModels", new[] { "WorkersModel_ID_worker" });
            DropIndex("dbo.AdressModels", new[] { "ClientModel_ID_client" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.WorkersModels");
            DropTable("dbo.PartModels");
            DropTable("dbo.MendingModels");
            DropTable("dbo.MendingListModels");
            DropTable("dbo.DealerModels");
            DropTable("dbo.ClientModels");
            DropTable("dbo.CarModels");
            DropTable("dbo.AdressModels");
        }
    }
}
