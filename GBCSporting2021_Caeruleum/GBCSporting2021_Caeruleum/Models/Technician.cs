using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GBCSporting2021_Caeruleum.Models
{
  public class Technician
  {
    public int Id { get; set; }
    [Required(ErrorMessage = "First name required.")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Last name required.")]
    public string LastName { get; set; }
    [Required(ErrorMessage = "e-mail is required..")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Phone number is required.")]
    public string Phone { get; set; }
  }
}
