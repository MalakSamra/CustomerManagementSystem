using CustomerManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystem.BL;

public interface IUserManager
{
    IEnumerable<UserAddReadDto> GetAllUsers();
    UserAddReadDto? GetUserById(string id);

}
