using CustomerManagementSystem.DAL.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystem.DAL;

public class CustomerRepo : ICustomerRepo
{
    private readonly UserContext _context;
    public CustomerRepo (UserContext context)
    {
        _context = context;
    }
    public int AddCustomer(Customer entity)
    {
        _context.Set<Customer>().Add(entity);
        return entity.Id;
    }

    public void DeleteCustomer(Customer entity)
    {
        _context.Set<Customer>().Remove(entity);
    }

    public IEnumerable<Customer> GetAllCustomers()
    {
        return _context.Set<Customer>().AsNoTracking();
    }

    public Customer? GetCustomerById(int id)
    {
        return _context.Set<Customer>().Find(id);
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public void UpdateCustomer(Customer entity){}
}
