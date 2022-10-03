using Microsoft.AspNetCore.Mvc;
using SheCollectionBE.Models;
using SheCollectionBE.Response_Models;
using SheCollectionBE.Services.CustomerService;
using SheCollectionBE.Services.UserService;

namespace SheCollectionBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseController
    {
        private ICustomerService customerService;
        private IUserService userService;

        public CustomerController(ICustomerService customerService, IUserService userService)
        {
            this.customerService = customerService;
            this.userService = userService;
        }

        [HttpGet("GetCustomer")]
        public async Task<IActionResult> GetCustomer([FromQuery] int userId)
        {
            CustomerTable cust = this.customerService.GetByUserId(userId);

            if(cust == null)
                return NotFound();

            return Ok(new CustomerResponse(cust));
        }
    }
}
