namespace BelajarMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        intCustomerId = c.Int(nullable: false, identity: true),
                        txtCustomerName = c.String(),
                        txtCustomerAddress = c.String(),
                        bitGender = c.Boolean(nullable: false),
                        dtmBirthDate = c.DateTime(nullable: false),
                        dtInserted = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.intCustomerId);
            
            CreateTable(
                "dbo.Penjualans",
                c => new
                    {
                        intSalesOrderId = c.Int(nullable: false, identity: true),
                        intCustomerId = c.Int(nullable: false),
                        intProductId = c.Int(nullable: false),
                        dtSalesOrder = c.DateTime(nullable: false),
                        intQty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.intSalesOrderId)
                .ForeignKey("dbo.Customers", t => t.intCustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Produks", t => t.intProductId, cascadeDelete: true)
                .Index(t => t.intCustomerId)
                .Index(t => t.intProductId);
            
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
            DropForeignKey("dbo.Penjualans", "intProductId", "dbo.Produks");
            DropForeignKey("dbo.Penjualans", "intCustomerId", "dbo.Customers");
            DropIndex("dbo.Penjualans", new[] { "intProductId" });
            DropIndex("dbo.Penjualans", new[] { "intCustomerId" });
            DropTable("dbo.Produks");
            DropTable("dbo.Penjualans");
            DropTable("dbo.Customers");
        }
    }
}
