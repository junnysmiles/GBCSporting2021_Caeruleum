using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GBCSporting2021_Caeruleum.Models
{
  public class Registration
  {
    public int Id { get; set; }

    [ForeignKey("Customer")]
    [Required(ErrorMessage = "Customer is required!")]
    public int CustomerId { get; set; }

    [ForeignKey("Product")]
    [Required(ErrorMessage = "Product is required!")]
    public int ProductId { get; set; }
  }
}
