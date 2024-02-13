using Microsoft.AspNetCore.Mvc;
using PinewoodAssessment.Models;
using PinewoodAssessment.Repositories;
using System.Collections.Generic;

namespace PinewoodAssessment.API
{


    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerRepository CustomerRepository;

        public CustomersController()
        {
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            return (List<PinewoodAssessment.Models.Customer>)CustomerRepository.Instance.GetAllCustomers();
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomerById(int id)
        {
            var customer = CustomerRepository.GetCustomerById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public ActionResult<Customer> AddCustomer(Customer customer)
        {
            CustomerRepository.Instance.AddCustomer(customer);

            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
        }

        //Not used
        [HttpPut]
        public IActionResult UpdateCustomer(Customer updatedCustomer)
        {
            CustomerRepository.Instance.UpdateCustomer(updatedCustomer);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            CustomerRepository.Instance.DeleteCustomer(id);

            return NoContent();
        }
    }


}
