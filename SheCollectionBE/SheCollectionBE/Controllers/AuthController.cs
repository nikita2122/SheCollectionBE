using Microsoft.AspNetCore.Mvc;
using SheCollectionBE.DB_Models;
using SheCollectionBE.Helpers;
using SheCollectionBE.Models;
using SheCollectionBE.Request_Models;
using SheCollectionBE.Response_Models;
using SheCollectionBE.Services.AuthService;
using SheCollectionBE.Services.CustomerService;
using SheCollectionBE.Services.EmailService;
using SheCollectionBE.Services.UserService;

namespace SheCollectionBE.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IAuthService authService;
        private readonly IEmailService emailService;
        private readonly ICustomerService customerService;
        private readonly IUserService userService;

        public AuthController(IAuthService authService, IEmailService emailService, ICustomerService customerService, IUserService userService)
        {
            this.authService = authService;
            this.emailService = emailService;
            this.customerService = customerService;
            this.userService = userService;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginModel user)
        {
            if (user is null)
                return BadRequest("Invalid client request");

            AuthenticatedResponse resp = authService.Login(user);

            return resp == null ? Unauthorized() : Ok(resp);
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterModel user)
        {
            if (user is null)
                return BadRequest("Invalid registration model");

            AuthenticatedResponse resp = authService.Register(user);

            return resp == null ? Unauthorized() : Ok(resp);
        }

        [HttpPost("UpdateAccount")]
        public IActionResult UpdateAccount([FromBody] UpdateAccount user)
        {
            if (user is null)
                return BadRequest("Invalid account model");

            return authService.UpdateAccount(user) ? Ok() : NotFound();
        }

        [HttpPost("UpdatePassword")]
        public IActionResult UpdatePassword(UpdatePasswordModel passwdModel)
        {
            if (passwdModel is null)
                return BadRequest("Invalid model");

            return authService.UpdatePassword(passwdModel) ? Ok() : NotFound();
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
        {
            List<EmailResetModel> models = this.emailService.GetBy(e => e.EmailAddress == model.email && e.Code == model.code);
            if (models.Count <= 0)
                return Unauthorized();

            emailService.Delete(models[0].EmailResetId);

            authService.ResetPassword(model.email, model.newPassword);

            return Ok();
        }
    }
}
