using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystem.DAL;

[PrimaryKey(nameof(UserID), nameof(CustomerId))]

public class Customer_User
{
    public string? UserID { get; set; }
    public User? User { get; set; }
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }

    [Column(TypeName = "date")]
    public DateTime EntryDate { get; set; }
    [Column(TypeName = "date")]
    public DateTime ModificationDate { get; set; }
    public string? Modification_UserID { get; set; }
    public User? Modification_User { get; set; }

}
