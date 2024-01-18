using CustomerManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystem.BL;

public interface ICustomerUserManager
{
    IEnumerable<CustomerUserDto> GetAll();
    CustomerUserDto? GetById(int cstId);
    void Add(CustomerUserDto cst_usr);
    void UpdateUser(CustomerUserDto cst_usr);
    bool DeleteUser(int id);
}
