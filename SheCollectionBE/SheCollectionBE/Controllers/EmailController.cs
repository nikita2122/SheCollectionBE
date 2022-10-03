using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SheCollectionBE.Models;
using SheCollectionBE.Services.CustomerService;
using SheCollectionBE.Services.EmailService;
using SheCollectionBE.Services.UserService;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace SheCollectionBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService emailService;
        private readonly ICustomerService customerService;
        private readonly IUserService userService;

        public EmailController(IEmailService emailService, ICustomerService customerService, IUserService userService)
        {
            this.emailService = emailService;
            this.customerService = customerService;
            this.userService = userService;
        }

        [HttpGet("SendForgotPasswordEmail")]
        public async Task<IActionResult> SendForgotPasswordEmail([FromQuery] string email)
        {
            if(customerService.GetBy(c => c.CustomerEmail == email).Count <= 0)
                return NotFound();

            return emailService.SendResetMail(email) ? Ok() : NotFound();
        }
    }
}
