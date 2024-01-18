using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystem.DAL;

public class UserContext : IdentityDbContext
{
    public DbSet<Customer> customer { get; set; }
    public DbSet<User> users { get; set; }
    public DbSet<Customer_User> customer_user { get; set; }
    public UserContext(DbContextOptions<UserContext> options): base(options) { }
}
