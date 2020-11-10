using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BelajarMvc.Models
{
  public class Produk
  {
    [Key]
    [DisplayName("Product ID")]
    public int intProductId { get; set; }
        
    [DisplayName("Product Code")]
    public string txtProductCode { get; set; }
        
    [DisplayName("Product Name")]
    public string txtProductName { get; set; }
        
    [DisplayName("Quantity")]
    public int intQty { get; set; }
        
    [DisplayName("Price")]
    [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
    public decimal decPrice { get; set; }
        
    [DisplayName("Date Inserted")]
    public DateTime dtInserted { get; set; }
  }
}