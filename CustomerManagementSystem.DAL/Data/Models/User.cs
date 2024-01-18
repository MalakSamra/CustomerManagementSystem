using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystem.DAL;

public class User : IdentityUser
{
    public string Name { get; set; } = string.Empty;

    //Navigation Property
    public ICollection<Customer> customers { get; set; } = new HashSet<Customer>();
}
