using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystem.BL;

public class CustomerAddDto
{
    public string Name { get; set; } = string.Empty;
    public string Nationality { get; set; } = string.Empty;
    public string Mobile_Number { get; set; } = string.Empty;
    public string Telephone1 { get; set; } = string.Empty;
    public string Telephone2 { get; set; } = string.Empty;
    public string Whatsapp_Number { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Job { get; set; } = string.Empty;
    public string Entry_Agent { get; set; } = string.Empty;
    [Column(TypeName = "date")]
    public DateTime Entry_Date { get; set; }
    public string Sales_man { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;
    [Column(TypeName = "decimal(10,2)")]
    public decimal Rating { get; set; }
}
