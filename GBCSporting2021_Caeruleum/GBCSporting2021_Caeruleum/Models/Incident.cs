using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GBCSporting2021_Caeruleum.Models
{
  public class Incident
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "Customer is required for incident report.")]
    [ForeignKey("CustomerId")]
    public int CustomerId { get; set; }

    [Required(ErrorMessage = "Product is required for incident report.")]
    [ForeignKey("ProductId")]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Technician needs to be assigned to incident.")]
    [ForeignKey("TechnicianId")]
    public int? TechnicianId { get; set; }
 
    [Required(ErrorMessage = "Title is required.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Opening Date reqiured.")]
    public DateTime OpenDate { get; set; }
    
    public DateTime? CloseDate { get; set; }

    public string NullDateToString(DateTime? dateTime, string format)
    {
      return dateTime == null ? "" : ((DateTime)dateTime).ToString(format);
    }

  }
}
