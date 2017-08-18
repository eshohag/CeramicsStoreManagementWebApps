namespace CeramicsStoreManagementWebApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Okkkkk : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.ProductDisplays");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductDisplays",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Brand = c.String(),
                        MinSellingPrice = c.Double(nullable: false),
                        MaxSellingPrice = c.Double(nullable: false),
                        ManufacturingCountry = c.String(),
                        Quentity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
    }
}
