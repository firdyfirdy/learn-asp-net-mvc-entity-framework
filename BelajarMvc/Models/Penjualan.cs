using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BelajarMvc.Models
{
  public class Penjualan
  {
    [Key]
    [DisplayName("SO ID")]
    public int intSalesOrderId { get; set; }

    [ForeignKey("Customer")]
    [DisplayName("Cust. ID")]
    public int intCustomerId { get; set; }

    [ForeignKey("Produk")]
    [DisplayName("Product Code")]
    public int intProductId { get; set; }

        
    [DisplayName("Date Order")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:d-MMM-yyyy}", ApplyFormatInEditMode =true)]
    public DateTime dtSalesOrder { get; set; }
        
    [DisplayName("Quantity")]
    public int intQty { get; set; }

    public virtual Produk Produk { get; set; }
    public virtual Customer Customer { get; set; }
  }
}