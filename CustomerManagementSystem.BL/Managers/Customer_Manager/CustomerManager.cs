using CustomerManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystem.BL;

public class CustomerManager : ICustomerManager
{
    private readonly ICustomerRepo _customerRepo;
    public CustomerManager(ICustomerRepo customerRepo)
    {
        _customerRepo = customerRepo;
    }

    public int AddCustomer(CustomerAddDto customer)
    {
        Customer cst = new Customer {
            Name = customer.Name,
            Address = customer.Address,
            Nationality = customer.Nationality,
            Mobile_Number = customer.Mobile_Number,
            Telephone1 = customer.Telephone1,
            Telephone2 = customer.Telephone2,
            Whatsapp_Number = customer.Whatsapp_Number,
            Email = customer.Email,
            Description = customer.Description,
            Job = customer.Job,
            Source = customer.Source,
            Sales_man = customer.Sales_man,
            Rating = customer.Rating
        };
        _customerRepo.AddCustomer( cst );
        _customerRepo.SaveChanges();
        return cst.Id;
    }

    public bool DeleteCustomer(int id)
    {
        Customer? customer = _customerRepo.GetCustomerById(id);
        if(customer == null) { return false; }
        _customerRepo.DeleteCustomer(customer);
        _customerRepo.SaveChanges();
        return true;
    }

    public IEnumerable<CustomerReadDto> GetAllCustomers()
    {
        var customersFromDB = _customerRepo.GetAllCustomers();
        return customersFromDB.Select(c => new CustomerReadDto
        {
            Id = c.Id,
            Name = c.Name,
            Nationality = c.Nationality,
            Mobile_Number = c.Mobile_Number,
            Telephone1 = c.Telephone1,
            Telephone2 = c.Telephone2,
            Whatsapp_Number = c.Whatsapp_Number,
            Email = c.Email,
            Address = c.Address,
            Description = c.Description,
            Job = c.Job,
            Sales_man = c.Sales_man,
            Source = c.Source,
            Rating = c.Rating
        });
    }

    public CustomerReadDto? GetCustomerById(int id)
    {
        Customer? customerFromDB = _customerRepo.GetCustomerById(id);
        if (customerFromDB == null) { return null; }
        return new CustomerReadDto
        {
            Id = customerFromDB.Id,
            Name = customerFromDB.Name,
            Nationality = customerFromDB.Nationality,
            Mobile_Number = customerFromDB.Mobile_Number,
            Telephone1 = customerFromDB.Telephone1,
            Telephone2 = customerFromDB.Telephone2,
            Whatsapp_Number = customerFromDB.Whatsapp_Number,
            Email = customerFromDB.Email,
            Address = customerFromDB.Address,
            Description = customerFromDB.Description,
            Job = customerFromDB.Job,
            Sales_man = customerFromDB.Sales_man,
            Source = customerFromDB.Source,
            Rating = customerFromDB.Rating
        };
    }

    public bool UpdateCustomer(CustomerUpdateDto customerFromRequest)
    {
        Customer? cst = _customerRepo.GetCustomerById(customerFromRequest.Id);
        if (cst == null) { return false;}
        cst.Name = customerFromRequest.Name;
        cst.Address = customerFromRequest.Address;
        cst.Nationality = customerFromRequest.Nationality;
        cst.Mobile_Number = customerFromRequest.Mobile_Number;
        cst.Telephone1 = customerFromRequest.Telephone1;
        cst.Telephone2 = customerFromRequest.Telephone2;
        cst.Whatsapp_Number = customerFromRequest.Whatsapp_Number;
        cst.Email = customerFromRequest.Email;
        cst.Description = customerFromRequest.Description;
        cst.Job = customerFromRequest.Job;
        cst.Source = customerFromRequest.Source;
        cst.Sales_man = customerFromRequest.Sales_man;
        cst.Rating = customerFromRequest.Rating;
        _customerRepo.UpdateCustomer(cst);
        _customerRepo.SaveChanges();
        return true;
    }
}
