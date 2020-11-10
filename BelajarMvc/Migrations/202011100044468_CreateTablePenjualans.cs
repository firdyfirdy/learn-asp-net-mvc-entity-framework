namespace BelajarMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTablePenjualans : DbMigration
    {
        public override void Up()
        {
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
        }

        public override void Down()
        {
            DropForeignKey("dbo.Penjualans", "intProductId", "dbo.Produks");
            DropForeignKey("dbo.Penjualans", "intCustomerId", "dbo.Customers");
            DropIndex("dbo.Penjualans", new[] { "intProductId" });
            DropIndex("dbo.Penjualans", new[] { "intCustomerId" });
            DropTable("dbo.Penjualans");
        }
    }
}
