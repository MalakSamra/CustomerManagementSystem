using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystem.DAL;

public interface ICustomerUserRepo
{
    IEnumerable<Customer_User> GetAll();
    void Add (Customer_User entity);
    void UpdateUser (Customer_User entity);
    void DeleteUser (Customer_User entity);
    int SaveChanges();
}
