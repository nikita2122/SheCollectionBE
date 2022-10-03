using SheCollectionBE.Models;

namespace SheCollectionBE.Services.CustomerService
{
    public interface ICustomerService : IService<CustomerTable>
    {
        CustomerTable GetByUserId(int userId);
        CustomerTable CreateWithUser(UserTable user);
    }
}
