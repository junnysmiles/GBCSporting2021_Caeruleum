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
    [ForeignKey("CustomerId")]
    public int CustomerId { get; set; }

    [ForeignKey("ProductId")]
    public int ProductId { get; set; }
  }
}
