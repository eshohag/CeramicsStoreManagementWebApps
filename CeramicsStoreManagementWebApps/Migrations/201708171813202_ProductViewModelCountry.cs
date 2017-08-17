namespace CeramicsStoreManagementWebApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductViewModelCountry : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ManufacturingCountry = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.ProductViewModels", "CountryID", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductViewModels", "CountryID");
            AddForeignKey("dbo.ProductViewModels", "CountryID", "dbo.Countries", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductViewModels", "CountryID", "dbo.Countries");
            DropIndex("dbo.ProductViewModels", new[] { "CountryID" });
            DropColumn("dbo.ProductViewModels", "CountryID");
            DropTable("dbo.Countries");
        }
    }
}
