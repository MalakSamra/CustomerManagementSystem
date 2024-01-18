using CustomerManagementSystem.BL;
using CustomerManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystem;

public class CustomerUserManager : ICustomerUserManager
{
    private readonly ICustomerUserRepo _customerUserRepo;
    public CustomerUserManager(ICustomerUserRepo customerUserRepo)
    {
        _customerUserRepo = customerUserRepo;
    }
    public void Add(CustomerUserDto cst_usr)
    {
        Customer_User cu = new Customer_User
        {
            UserID = cst_usr.UserID,
            Cst_id = cst_usr.Cst_id,
            EntryDate = cst_usr.EntryDate,
            Modification_UserID = cst_usr.Modification_UserID,
            ModificationDate = cst_usr.ModificationDate
        };
        _customerUserRepo.Add(cu);
        _customerUserRepo.SaveChanges();
    }

    public bool DeleteCstUser(int id)
    {
        Customer_User? customer_User = _customerUserRepo.GetById(id);
        if (customer_User == null) { return false; }
        _customerUserRepo.DeleteCstUser(customer_User);
        _customerUserRepo.SaveChanges();
        return true;
    }

    public IEnumerable<CustomerUserDto> GetAll()
    {
        var cuFromDB = _customerUserRepo.GetAll();
        return cuFromDB.Select(cu => new CustomerUserDto
        {
            UserID = cu.UserID,
            Cst_id = cu.Cst_id,
            EntryDate = cu.EntryDate,
            Modification_UserID = cu.Modification_UserID,
            ModificationDate = cu.ModificationDate
        });
    }

    public CustomerUserDto? GetById(int cstId)
    {
        var cuFromDB = _customerUserRepo.GetById(cstId);
        if (cuFromDB == null) { return null; }
        return new CustomerUserDto 
        {
            UserID = cuFromDB.UserID,
            Cst_id = cuFromDB.Cst_id,
            EntryDate = cuFromDB.EntryDate,
            Modification_UserID = cuFromDB.Modification_UserID,
            ModificationDate = cuFromDB.ModificationDate
        };
    }

    public bool UpdateCstUser(CustomerUserDto cst_usrFromRequest)
    {
        Customer_User? cu = _customerUserRepo.GetById(cst_usrFromRequest.Cst_id);
        if (cu == null) { return false; }
        cu.UserID = cst_usrFromRequest.UserID;
        cu.Cst_id = cst_usrFromRequest.Cst_id;
        cu.EntryDate = cst_usrFromRequest.EntryDate;
        cu.ModificationDate = cst_usrFromRequest.ModificationDate;
        cu.Modification_UserID = cst_usrFromRequest.Modification_UserID;
        _customerUserRepo.UpdateCstUser(cu);
        _customerUserRepo.SaveChanges();
        return true;
    }
}
