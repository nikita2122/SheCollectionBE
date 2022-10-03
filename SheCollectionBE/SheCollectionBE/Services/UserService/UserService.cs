using Microsoft.EntityFrameworkCore;
using SheCollectionBE.Context;
using SheCollectionBE.Models;

namespace SheCollectionBE.Services.UserService
{
    public class UserService : Service<UserTable>, IUserService
    {
        public UserService(SheCollectionContext context) : base(context)
        {
        }

        public override UserTable Create(UserTable entity)
        {
            UserTable userTable = context.UserTables.Add(entity).Entity;
            context.SaveChanges();
            return userTable;
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<UserTable> GetAll()
        {
            throw new NotImplementedException();
        }

        public override List<UserTable> GetBy(Func<UserTable, bool> predicate)
        {
            return context.UserTables.Include(u => u.UserRole).Where(predicate).ToList();
        }

        public override UserTable GetById(int id)
        {
            return context.UserTables.Include(u => u.UserRole).FirstOrDefault(u => u.UserTableId == id);
        }

        public UserTable GetByUsername(string username)
        {
            return context.UserTables.Include(u => u.UserRole).FirstOrDefault(u => u.UserName == username);
        }

        public override bool Update(int id, UserTable entity)
        {
            UserTable user = GetById(id);

            user.UserName = entity.UserName;
            user.UserPassword = entity.UserPassword;
            user.UserRole = entity.UserRole;
            user.Picture = entity.Picture;

            context.SaveChanges();

            return true;
        }
    }
}
