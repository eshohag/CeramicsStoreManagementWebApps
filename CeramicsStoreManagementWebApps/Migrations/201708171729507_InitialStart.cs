namespace CeramicsStoreManagementWebApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialStart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Billings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Total = c.Double(nullable: false),
                        Profit = c.Double(nullable: false),
                        Loss = c.Double(nullable: false),
                        ClientID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        PaymentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clients", t => t.ClientID, cascadeDelete: true)
                .ForeignKey("dbo.Payments", t => t.PaymentID, cascadeDelete: true)
                .Index(t => t.ClientID)
                .Index(t => t.PaymentID);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ContactNo = c.String(nullable: false),
                        Email = c.String(),
                        Address = c.String(nullable: false),
                        ReferenceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.References", t => t.ReferenceID, cascadeDelete: true)
                .Index(t => t.ReferenceID);
            
            CreateTable(
                "dbo.References",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ContactNo = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TotalCost = c.Double(nullable: false),
                        TotalDue = c.Double(nullable: false),
                        StatusID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Status", t => t.StatusID, cascadeDelete: true)
                .Index(t => t.StatusID);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Payment = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Color = c.String(),
                        Size = c.String(),
                        Description = c.String(),
                        BrandID = c.Int(nullable: false),
                        PriceID = c.Int(nullable: false),
                        Billing_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Brands", t => t.BrandID, cascadeDelete: true)
                .ForeignKey("dbo.Prices", t => t.PriceID, cascadeDelete: true)
                .ForeignKey("dbo.Billings", t => t.Billing_ID)
                .Index(t => t.BrandID)
                .Index(t => t.PriceID)
                .Index(t => t.Billing_ID);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ManufacturingCountry = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Purches = c.Double(nullable: false),
                        MinSelling = c.Double(nullable: false),
                        MaxSelling = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.RoleId)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Quentity = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
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
                .PrimaryKey(t => t.UserId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.UserClaim",
                c => new
                    {
                        UserClaimId = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.UserClaimId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserLogin", "UserId", "dbo.User");
            DropForeignKey("dbo.UserClaim", "UserId", "dbo.User");
            DropForeignKey("dbo.Stores", "ProductID", "dbo.Products");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.Products", "Billing_ID", "dbo.Billings");
            DropForeignKey("dbo.Products", "PriceID", "dbo.Prices");
            DropForeignKey("dbo.Products", "BrandID", "dbo.Brands");
            DropForeignKey("dbo.Billings", "PaymentID", "dbo.Payments");
            DropForeignKey("dbo.Payments", "StatusID", "dbo.Status");
            DropForeignKey("dbo.Billings", "ClientID", "dbo.Clients");
            DropForeignKey("dbo.Clients", "ReferenceID", "dbo.References");
            DropIndex("dbo.UserLogin", new[] { "UserId" });
            DropIndex("dbo.UserClaim", new[] { "UserId" });
            DropIndex("dbo.User", "UserNameIndex");
            DropIndex("dbo.Stores", new[] { "ProductID" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.Role", "RoleNameIndex");
            DropIndex("dbo.Products", new[] { "Billing_ID" });
            DropIndex("dbo.Products", new[] { "PriceID" });
            DropIndex("dbo.Products", new[] { "BrandID" });
            DropIndex("dbo.Payments", new[] { "StatusID" });
            DropIndex("dbo.Clients", new[] { "ReferenceID" });
            DropIndex("dbo.Billings", new[] { "PaymentID" });
            DropIndex("dbo.Billings", new[] { "ClientID" });
            DropTable("dbo.UserLogin");
            DropTable("dbo.UserClaim");
            DropTable("dbo.User");
            DropTable("dbo.Stores");
            DropTable("dbo.UserRole");
            DropTable("dbo.Role");
            DropTable("dbo.Prices");
            DropTable("dbo.Brands");
            DropTable("dbo.Products");
            DropTable("dbo.Status");
            DropTable("dbo.Payments");
            DropTable("dbo.References");
            DropTable("dbo.Clients");
            DropTable("dbo.Billings");
        }
    }
}
