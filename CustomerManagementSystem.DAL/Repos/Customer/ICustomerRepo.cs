using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystem.DAL;

public interface ICustomerRepo
{
    IEnumerable<Customer> GetAllCustomers();
    Customer? GetCustomerById(int id);
    int AddCustomer(Customer entity);
    void UpdateCustomer (Customer entity);
    void DeleteCustomer(Customer entity);
    int SaveChanges();
}
