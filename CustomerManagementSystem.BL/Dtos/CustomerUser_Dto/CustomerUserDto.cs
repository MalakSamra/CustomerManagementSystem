using CustomerManagementSystem.DAL;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystem.BL;

public class CustomerUserDto
{
    public string? UserID { get; set; }
    public int Cst_id { get; set; }
    [Column(TypeName = "date")]
    public DateTime EntryDate { get; set; }
    [Column(TypeName = "date")]
    public DateTime ModificationDate { get; set; }
    public string? Modification_UserID { get; set; }
}
