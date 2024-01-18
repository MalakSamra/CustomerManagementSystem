using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystem.DAL;
[PrimaryKey(nameof(UserID), nameof(Cst_id))]
public class Customer_User
{
    public string? UserID { get; set; }
    public User? User { get; set; }
    public int Cst_id { get; set; }
    public Customer? Customer { get; set; }

    [Column(TypeName = "date")]
    public DateTime EntryDate { get; set; }
    [Column(TypeName = "date")]
    public DateTime ModificationDate { get; set; }

}
