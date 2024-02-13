using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using PinewoodAssessment.Interface;
using PinewoodAssessment.Models;

namespace PinewoodAssesment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerService _customerService;

        public HomeController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IActionResult> Home()
        {
            IEnumerable<Customer> customers = await _customerService.GetCustomers();
            List<Customer> customerList = new List<Customer>(customers);
            return View(customerList);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] Customer newCustomer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _customerService.AddCustomer(newCustomer);
                    return RedirectToAction("Home");
                }
                else
                {
                    return BadRequest(new { Message = "Invalid customer data" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Error adding customer: {ex.Message}" });
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCustomer([FromBody] Customer Customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _customerService.UpdateCustomer(Customer);
                    return RedirectToAction("Home");
                }
                else
                {
                    return BadRequest(new { Message = "Invalid customer data" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Error adding customer: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCustomer([FromBody] Customer newCustomer)
        {
            try
            {
                if (newCustomer.Id != 0)
                {
                    await _customerService.DeleteCustomer(newCustomer.Id);
                    return RedirectToAction("Home");
                }
                else
                {
                    return BadRequest(new { Message = "Invalid customer data" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Error adding customer: {ex.Message}" });
            }
        }
    }
}
