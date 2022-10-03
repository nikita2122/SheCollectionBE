using Microsoft.IdentityModel.Tokens;
using SheCollectionBE.Helpers;
using SheCollectionBE.Models;
using SheCollectionBE.Request_Models;
using SheCollectionBE.Response_Models;
using SheCollectionBE.Services.CustomerService;
using SheCollectionBE.Services.TitleService;
using SheCollectionBE.Services.UserRoleService;
using SheCollectionBE.Services.UserService;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SheCollectionBE.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private IConfiguration config;
        private IUserService userService;
        private ICustomerService customerService;
        private ITitleService titleService;
        private IUserRoleService userRoleService;

        public AuthService(IConfiguration config, IUserService userService, ICustomerService customerService, ITitleService titleService, IUserRoleService userRoleService)
        {
            this.config = config;
            this.userService = userService;
            this.customerService = customerService;
            this.titleService = titleService;
            this.userRoleService = userRoleService;
        }

        public AuthenticatedResponse? Login(LoginModel user)
        {
            UserTable db_user = userService.GetByUsername(user.UserName);

            if (db_user == null)
                return null;

            if (db_user.UserPassword != Hasher.HashPassword(user.Password))
                return null;

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Issuer"],
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return new AuthenticatedResponse { Token = tokenString, role = db_user.UserRole, userId = db_user.UserTableId };
        }

        public AuthenticatedResponse? Register(RegisterModel model)
        {
            if (userService.GetBy(u => u.UserName == model.username).Count > 0)
            {
                return null;
            }

            UserTable user = new UserTable()
            {
                UserName = model.username,
                UserPassword = Hasher.HashPassword(model.password),
                Picture = model.picture,
                UserRole = userRoleService.GetBy(ur => ur.UserRoleName == "Customer")[0]
            };

            UserTable insertedUser = userService.Create(user);

            CustomerTable customer = new CustomerTable()
            {
                CustomerPhoneNumber = model.contact,
                Title = titleService.GetBy(t => t.TitleName == "Mr")[0],
                CustomerEmail = model.email,
                CustomerSurname = model.lastname,
                CustomerName = model.firstname,
                User = insertedUser,
            };

            CustomerTable insertedCustomer = customerService.Create(customer);

            LoginModel loginModel = new LoginModel()
            {
                UserName = model.username,
                Password = model.password
            };

            return Login(loginModel);
        }

        public bool ResetPassword(string email, string password)
        {
            CustomerTable customer = customerService.GetBy(c => c.CustomerEmail == email)[0];

            customer.User.UserPassword = Hasher.HashPassword(password);

            return userService.Update(customer.User.UserTableId, customer.User);
        }

        public bool UpdateAccount(UpdateAccount model)
        {
            UserTable user = userService.GetBy(u => u.UserName == model.username)[0];

            if (userRoleService == null)
                return false;

            CustomerTable customer = customerService.GetByUserId(user.UserTableId);

            user.Picture = model.picture;

            customer.CustomerPhoneNumber = model.contact;
            customer.Title = titleService.GetBy(t => t.TitleName == "Mr")[0];
            customer.CustomerEmail = model.email;
            customer.CustomerSurname = model.lastname;
            customer.CustomerName = model.firstname;

            userService.Update(user.UserTableId, user);
            customerService.Update(customer.CustomerTableId, customer);

            return true;
        }

        public bool UpdatePassword(UpdatePasswordModel passwdModel)
        {
            CustomerTable customer = customerService.GetBy(c => c.CustomerEmail == passwdModel.email)[0];

            if (customer == null)
                return false;

            UserTable user = customer.User;

            if (Hasher.HashPassword(passwdModel.oldPassword) != user.UserPassword)
                return false;

            user.UserPassword = Hasher.HashPassword(passwdModel.newPassword);

            return userService.Update(user.UserTableId, user);
        }
    }
}
