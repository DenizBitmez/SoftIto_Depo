namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mgr5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Barcodes",
                c => new
                    {
                        BarcodeId = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        MovementType = c.Boolean(nullable: false),
                        Quantity = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BarcodeId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            DropColumn("dbo.Products", "Barcode");
            DropColumn("dbo.StockDetails", "MovementType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StockDetails", "MovementType", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Products", "Barcode", c => c.String(nullable: false));
            DropForeignKey("dbo.Barcodes", "ProductId", "dbo.Products");
            DropIndex("dbo.Barcodes", new[] { "ProductId" });
            DropTable("dbo.Barcodes");
        }
    }
}
