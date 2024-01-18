using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystem.DAL;

public class CustomerUserRepo : ICustomerUserRepo
{
    private readonly UserContext _context;
    public CustomerUserRepo(UserContext context)
    {
        _context = context;
    }
    public void Add(Customer_User entity)
    {
        _context.Set<Customer_User>().Add(entity);
    }

    public void DeleteCstUser(Customer_User entity)
    {
        _context.Set<Customer_User>().Remove(entity);
    }

    public IEnumerable<Customer_User> GetAll()
    {
        return _context.Set<Customer_User>().AsNoTracking();
    }
    public Customer_User? GetById(int cstId)
    {
        return _context.Set<Customer_User>()
            .FirstOrDefault(cu => cu.Cst_id == cstId);
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public void UpdateCstUser(Customer_User entity){}
}
