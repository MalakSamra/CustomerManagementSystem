using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystem.DAL;

public interface ICustomerUserRepo
{
    IEnumerable<Customer_User> GetAll();
    Customer_User? GetById(int cstId);
    void Add (Customer_User entity);
    void UpdateCstUser (Customer_User entity);
    void DeleteCstUser (Customer_User entity);
    int SaveChanges();
}
