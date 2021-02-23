using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GBCSporting2021_Caeruleum.Models
{
  public class Customer
  {
    public int Id { get; set; }
    [Required(ErrorMessage = "First name required.")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Last name required.")]
    public string LastName { get; set; }
    [Required(ErrorMessage = "Address required.")]
    public string Address { get; set; }
    [Required(ErrorMessage = "City required.")]
    public string City { get; set; }
    [Required(ErrorMessage = "Postal Code required.")]
    public string PostalCode { get; set; }
    [Required(ErrorMessage = "Phone number is required.")]
    public string Phone { get; set; }
  }
}
