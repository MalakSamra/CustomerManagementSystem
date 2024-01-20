using CustomerManagementSystem.BL;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerUserController : Controller
    {
        private readonly ICustomerUserManager _customerUserManager;
        public CustomerUserController(ICustomerUserManager customerUserManager)
        {
            _customerUserManager = customerUserManager;
        }
        [HttpGet]
        public ActionResult<List<CustomerUserDto>> GetAllCustomerUsers()
        {
            return _customerUserManager.GetAll().ToList();
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<CustomerUserDto> GetCustomerUserById(int id)
        {
            CustomerUserDto? customerUser = _customerUserManager.GetById(id);
            if (customerUser == null)
            {
                return NotFound();
            }
            return customerUser;
        }
        [HttpPost]
        public ActionResult Add(CustomerUserDto customerUserDto)
        {
            _customerUserManager.Add(customerUserDto);
            return NoContent();
        }
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            var isFound = _customerUserManager.DeleteCstUser(id);
            if (!isFound)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpPut]
        public ActionResult Update(CustomerUserDto customerUserDto)
        {
            var isFound = _customerUserManager.UpdateCstUser(customerUserDto);
            if (!isFound)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
