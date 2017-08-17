namespace CeramicsStoreManagementWebApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductViewModel : DbMigration
    {
        public override void Up()
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
                        PurchesPrice = c.Double(nullable: false),
                        MinSellingPrice = c.Double(nullable: false),
                        MaxSellingPrice = c.Double(nullable: false),
                        Quentity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Brands", "ProductViewModel_ID", c => c.Int());
            CreateIndex("dbo.Brands", "ProductViewModel_ID");
            AddForeignKey("dbo.Brands", "ProductViewModel_ID", "dbo.ProductViewModels", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Brands", "ProductViewModel_ID", "dbo.ProductViewModels");
            DropIndex("dbo.Brands", new[] { "ProductViewModel_ID" });
            DropColumn("dbo.Brands", "ProductViewModel_ID");
            DropTable("dbo.ProductViewModels");
        }
    }
}
