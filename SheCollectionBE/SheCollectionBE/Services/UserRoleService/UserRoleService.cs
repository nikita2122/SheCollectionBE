using SheCollectionBE.Context;
using SheCollectionBE.Models;

namespace SheCollectionBE.Services.UserRoleService
{
    public class UserRoleService : Service<UserRole>, IUserRoleService
    {
        public UserRoleService(SheCollectionContext context) : base(context)
        {
        }

        public override UserRole Create(UserRole entity)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<UserRole> GetAll()
        {
            throw new NotImplementedException();
        }

        public override List<UserRole> GetBy(Func<UserRole, bool> predicate)
        {
            return context.UserRoles.Where(predicate).ToList();
        }

        public override UserRole GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(int id, UserRole entity)
        {
            throw new NotImplementedException();
        }
    }
}
