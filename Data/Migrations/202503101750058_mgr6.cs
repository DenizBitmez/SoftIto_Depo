namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mgr6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Barcodes", "CreatedDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Barcodes", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Barcodes", "Quantity", c => c.Int(nullable: false));
            DropColumn("dbo.Barcodes", "CreatedDate");
        }
    }
}
