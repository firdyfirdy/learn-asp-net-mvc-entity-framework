namespace BelajarMvc.Migrations
{
    using BelajarMvc.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.MainDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.MainDbContext context)
        {
            List<Produk> produks = new List<Produk>
            {
                new Produk()
                {
                    intProductId = 1,
                    decPrice = 30000,
                    dtInserted = DateTime.Now,
                    intQty = 100,
                    txtProductCode = "P00001",
                    txtProductName = "Pomade"
                },
                new Produk()
                {
                    intProductId = 2,
                    decPrice = 20000,
                    dtInserted = DateTime.Now,
                    intQty = 100,
                    txtProductCode = "P00002",
                    txtProductName = "Shampoo"
                },
                new Produk()
                {
                    intProductId = 3,
                    decPrice = 10000,
                    dtInserted = DateTime.Now,
                    intQty = 100,
                    txtProductCode = "P00003",
                    txtProductName = "Sabun"
                },
            };

            List<Customer> customers = new List<Customer>
            {
                new Customer()
                {
                    intCustomerId = 1,
                    bitGender = true,
                    dtInserted = DateTime.Now,
                    dtmBirthDate = DateTime.Now,
                    txtCustomerAddress = "Bojong Kulur",
                    txtCustomerName = "Firdy"
                },
                new Customer()
                {
                    intCustomerId = 2,
                    bitGender = true,
                    dtInserted = DateTime.Now,
                    dtmBirthDate = DateTime.Now,
                    txtCustomerAddress = "Kebon Jeruk",
                    txtCustomerName = "Habie"
                },
                new Customer()
                {
                    intCustomerId = 3,
                    bitGender = true,
                    dtInserted = DateTime.Now,
                    dtmBirthDate = DateTime.Now,
                    txtCustomerAddress = "Bassura",
                    txtCustomerName = "Margono"
                },
            };

            produks.ForEach(
                p => context.Produk.AddOrUpdate(p)
            );

            customers.ForEach(
                c => context.Customer.AddOrUpdate(c)
            );
        }
    }
}
