namespace CeramicsStoreManagementWebApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductViewM : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "PriceID", "dbo.Prices");
            DropForeignKey("dbo.Brands", "ProductViewModel_ID", "dbo.ProductViewModels");
            DropForeignKey("dbo.ProductViewModels", "CountryID", "dbo.Countries");
            DropIndex("dbo.Products", new[] { "PriceID" });
            DropIndex("dbo.Brands", new[] { "ProductViewModel_ID" });
            DropIndex("dbo.ProductViewModels", new[] { "CountryID" });
            AddColumn("dbo.Products", "CountryID", c => c.Int(nullable: false));
            AddColumn("dbo.Prices", "ProductID", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "CountryID");
            CreateIndex("dbo.Prices", "ProductID");
            AddForeignKey("dbo.Products", "CountryID", "dbo.Countries", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Prices", "ProductID", "dbo.Products", "ID", cascadeDelete: true);
            DropColumn("dbo.Products", "PriceID");
            DropColumn("dbo.Brands", "ManufacturingCountry");
            DropColumn("dbo.Brands", "ProductViewModel_ID");
            DropTable("dbo.ProductViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductViewModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Color = c.String(),
                        Size = c.String(),
                        Description = c.String(),
                        BrandID = c.Int(nullable: false),
                        CountryID = c.Int(nullable: false),
                        PurchesPrice = c.Double(nullable: false),
                        MinSellingPrice = c.Double(nullable: false),
                        MaxSellingPrice = c.Double(nullable: false),
                        Quentity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Brands", "ProductViewModel_ID", c => c.Int());
            AddColumn("dbo.Brands", "ManufacturingCountry", c => c.String());
            AddColumn("dbo.Products", "PriceID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Prices", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "CountryID", "dbo.Countries");
            DropIndex("dbo.Prices", new[] { "ProductID" });
            DropIndex("dbo.Products", new[] { "CountryID" });
            DropColumn("dbo.Prices", "ProductID");
            DropColumn("dbo.Products", "CountryID");
            CreateIndex("dbo.ProductViewModels", "CountryID");
            CreateIndex("dbo.Brands", "ProductViewModel_ID");
            CreateIndex("dbo.Products", "PriceID");
            AddForeignKey("dbo.ProductViewModels", "CountryID", "dbo.Countries", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Brands", "ProductViewModel_ID", "dbo.ProductViewModels", "ID");
            AddForeignKey("dbo.Products", "PriceID", "dbo.Prices", "ID", cascadeDelete: true);
        }
    }
}
