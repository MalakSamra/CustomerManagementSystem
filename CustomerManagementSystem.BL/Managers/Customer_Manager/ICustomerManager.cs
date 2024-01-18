using CustomerManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystem.BL;

public interface ICustomerManager
{
    IEnumerable<CustomerReadDto> GetAllCustomers();
    CustomerReadDto? GetCustomerById(int id);
    int AddCustomer(CustomerAddDto customer);
    bool UpdateCustomer(CustomerUpdateDto customer);
    bool DeleteCustomer(int id);
}
