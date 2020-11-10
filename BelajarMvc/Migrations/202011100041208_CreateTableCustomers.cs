namespace BelajarMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableCustomers : DbMigration
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
        }

        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
