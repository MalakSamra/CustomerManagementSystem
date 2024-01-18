using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystem.DAL;
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Job { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;
    [Column(TypeName = "decimal(10,2)")]
    public decimal Rating { get; set; }
    public string Sales_man { get; set; } = string.Empty;

    //Navigation Property
    public ICollection<User> users { get; set; } = new HashSet<User>();
}
