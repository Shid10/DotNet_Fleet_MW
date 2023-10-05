using FleetManagement_MW.Models.Services;
using FleetManagement_MW.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace FleetManagement_MW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class CustomerMasterController : ControllerBase
    {
        private readonly ICustomerMasterRepository _customerRepository;

        public CustomerMasterController(ICustomerMasterRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customers = _customerRepository.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomer(long id)
        {
            var customer = _customerRepository.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpGet("GetCustomerByEmail")]
        public IActionResult GetCustomerByEmail(string email)
        {
            var customer =  _customerRepository.GetCustomerByEmail(email);

            if (customer == null)
            {
                return NotFound() ; // Customer with the provided email not found
            }

            return Ok(customer); // Return customer details if found
        }

        [HttpPost]
        public IActionResult CreateCustomer(CustomerMaster customer)
        {
            if (ModelState.IsValid)
            {
                _customerRepository.AddCustomer(customer);
                _customerRepository.SaveChanges();
                return CreatedAtAction(nameof(GetCustomer), new { id = customer.customerId }, customer);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(long id, CustomerMaster customer)
        {
            if (id != customer.customerId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _customerRepository.UpdateCustomer(customer);
                _customerRepository.SaveChanges();
                return NoContent();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(long id)
        {
            var customer = _customerRepository.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }

            _customerRepository.RemoveCustomer(id);
            _customerRepository.SaveChanges();
            return NoContent();
        }
    }
}
