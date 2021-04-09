using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GBCSporting2021_Caeruleum.Models
{
  public class Customer
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "First name required.")]
    [StringLength(50, ErrorMessage = "Must be between 1 and 50 characters long.", MinimumLength = 1)]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Last name required.")]
    [StringLength(50, ErrorMessage = "Must be between 1 and 50 characters long.", MinimumLength = 1)]
    public string LastName { get; set; }
    
    [Required(ErrorMessage = "Address required.")]
    [StringLength(50, ErrorMessage = "Must be between 1 and 50 characters long.", MinimumLength = 1)]
    public string Address { get; set; }
    
    [Required(ErrorMessage = "City required.")]
    [StringLength(50, ErrorMessage = "Must be between 1 and 50 characters long.", MinimumLength = 1)]
    public string City { get; set; }
    [Required(ErrorMessage = "State required.")]
    [StringLength(50, ErrorMessage = "Must be between 1 and 50 characters long.", MinimumLength = 1)]
    public string State { get; set; }

    [Required(ErrorMessage = "Postal Code required.")]
    [StringLength(20, ErrorMessage = "Must be between 1 and 20 characters long.", MinimumLength = 1)]

    public string PostalCode { get; set; }
    
    [DataType(DataType.PhoneNumber)]
    public string Phone { get; set; }
    
    [Required(ErrorMessage = "Email address is required.")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required(ErrorMessage = "Country is required.")]
    [ForeignKey("Country")]
    public int CountryId { get; set; }
  }
}
