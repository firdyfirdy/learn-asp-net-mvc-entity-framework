namespace BelajarMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableProduks : DbMigration
    {
        public override void Up()
        {   
            CreateTable(
                "dbo.Produks",
                c => new
                    {
                        intProductId = c.Int(nullable: false, identity: true),
                        txtProductCode = c.String(),
                        txtProductName = c.String(),
                        intQty = c.Int(nullable: false),
                        decPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dtInserted = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.intProductId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Produks");
        }
    }
}
