namespace BelajarMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTriggerIncreaseProdukQty : DbMigration
    {
        public override void Up()
        {
            Sql("CREATE TRIGGER tr_IncreaseProdukQty " +
                "ON dbo.Penjualans " +
                "AFTER DELETE " +
                "AS " +
                "BEGIN " +
                "   SET NOCOUNT ON; " +
                "   Declare @IDProduk INT " +
                "   Declare @QtyPenjualan INT " +
                "   SELECT @IDProduk = intProductId FROM DELETED " +
                "   SELECT @QtyPenjualan = intQty FROM DELETED " +
                "   Update dbo.Produks " +
                "   SET dbo.Produks.intQty = dbo.Produks.intQty + @QtyPenjualan WHERE dbo.Produks.intProductId = @IDProduk " +
                "END ");
        }
        
        public override void Down()
        {
            Sql("DROP TRIGGER tr_IncreaseProdukQty");
        }
    }
}
