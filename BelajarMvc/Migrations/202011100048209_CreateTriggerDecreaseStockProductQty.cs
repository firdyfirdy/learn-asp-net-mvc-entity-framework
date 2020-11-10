namespace BelajarMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTriggerDecreaseStockProductQty : DbMigration
    {
        public override void Up()
        {
            Sql("CREATE TRIGGER tr_DecreaseProdukQty " +
                "ON dbo.Penjualans " +
                "AFTER INSERT " +
                "AS " +
                "BEGIN " +
                "   SET NOCOUNT ON; " +
                "   Declare @IDProduk INT " +
                "   Declare @QtyPenjualan INT " +
                "   SELECT @IDProduk = intProductId from inserted " +
                "   SELECT @QtyPenjualan = intQty from inserted " +
                "   Update dbo.Produks " +
                "   SET dbo.Produks.intQty = dbo.Produks.intQty - @QtyPenjualan WHERE dbo.Produks.intProductId = @IDProduk " +
                "END ");
        }

        public override void Down()
        {
            Sql("DROP TRIGGER tr_DecreaseProdukQty");
        }
    }
}
