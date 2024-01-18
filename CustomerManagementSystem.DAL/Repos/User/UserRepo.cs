using CustomerManagementSystem.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystem;

public class UserRepo : IUserRepo
{
    private readonly UserContext _context;
    public UserRepo (UserContext context)
    {
        _context = context;
    }
    public string AddUser(User entity)
    {
        _context.Set<User>().Add(entity);
        return entity.Id;
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _context.Set<User>().AsNoTracking();
    }

    public User? GetUserById(string id)
    {
        return _context.Set<User>().Find(id);
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}
