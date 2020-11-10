using BelajarMvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BelajarMvc.Data
{
  public class MainDbContext : DbContext
  {

    public DbSet<Penjualan> Penjualan { get; set; }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<Produk> Produk { get; set; }
  }
}