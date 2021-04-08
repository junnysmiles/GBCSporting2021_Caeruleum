using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GBCSporting2021_Caeruleum.Models
{
  public class Product
  {
    public int Id { get; set; }
    [Required(ErrorMessage = "Product code required.")]
    public string Code { get; set; }
    [Required(ErrorMessage = "Product name is required.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Price is required.")]
    public double Price { get; set; }
    [Required(ErrorMessage = "Release date is required.")]
    public DateTime ReleaseDate { get; set; }

    [Required(ErrorMessage = "Country is required.")]
    [ForeignKey("CountryId")]
    public int CountryId { get; set; }
  }
}
