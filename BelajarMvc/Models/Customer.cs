using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BelajarMvc.Models
{
  public class Customer
  {
    [Key]
    [DisplayName("Cust. ID")]
    public int intCustomerId { get; set; }
        
    [DisplayName("Cust. Name")]
    public string txtCustomerName { get; set; }
        
    [DisplayName("Cust. Address")]
    public string txtCustomerAddress { get; set; }
        
    [DisplayName("Gender")]
    public bool bitGender { get; set; }

    [DisplayName("Tanggal Lahir")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:d-MMM-yyyy}", ApplyFormatInEditMode =true)]
    public DateTime dtmBirthDate { get; set; }

    [DisplayName("Date Inserted")]
    public DateTime dtInserted { get; set; }
  }
}