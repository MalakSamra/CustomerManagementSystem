using CustomerManagementSystem.BL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerManager _customerManager;
        public CustomerController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }
        [HttpGet]
        public ActionResult<List<CustomerReadDto>> GetAllCustomers()
        {
            return _customerManager.GetAllCustomers().ToList();
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<CustomerReadDto> GetCustomerById(int id)
        {
            CustomerReadDto? customer = _customerManager.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }
        [HttpPost]
        public ActionResult Add(CustomerAddDto customerDto)
        {
            var newId = _customerManager.AddCustomer(customerDto);
            return CreatedAtAction(nameof(GetCustomerById),
                                    new { id = newId },
                                    new GeneralResponse("Customer has been added successfully"));
        }
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            var isFound = _customerManager.DeleteCustomer(id);
            if (!isFound)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpPut]
        public ActionResult Update(CustomerUpdateDto customerDto)
        {
            var isFound = _customerManager.UpdateCustomer(customerDto);
            if (!isFound)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
