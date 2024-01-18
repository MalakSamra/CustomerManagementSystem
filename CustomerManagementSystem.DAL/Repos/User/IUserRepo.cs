using CustomerManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystem;

public interface IUserRepo
{
    IEnumerable<User> GetAllUsers();
    User? GetUserById (string id);
    string AddUser (User entity);
    int SaveChanges();
}
