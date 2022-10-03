using SheCollectionBE.Models;

namespace SheCollectionBE.Services.UserService
{
    public interface IUserService : IService<UserTable>
    {
        UserTable GetByUsername(string username);
    }
}
