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
    public int CustomerId { get; set; }
    [ForeignKey("CustomerId")]

    public Customer Customer { get; set; }

    [Required(ErrorMessage = "Product is required for incident report.")]
    public int ProductId { get; set; }
    [ForeignKey("ProductId")]

    public Product Product { get; set; }

    [Required(ErrorMessage = "Technician needs to be assigned to incident.")]
    public int TechnicianId { get; set; }
    [ForeignKey("TechnicianId")]
    
    public Technician Technician { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Opening Date reqiured.")]
    public DateTime OpenDate { get; set; }
    
    public DateTime CloseDate { get; set; }

  }
}
