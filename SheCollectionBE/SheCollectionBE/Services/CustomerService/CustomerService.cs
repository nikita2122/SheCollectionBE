using Microsoft.EntityFrameworkCore;
using SheCollectionBE.Context;
using SheCollectionBE.Models;
using SheCollectionBE.Services.TitleService;

namespace SheCollectionBE.Services.CustomerService
{
    public class CustomerService : Service<CustomerTable>, ICustomerService
    {
        private readonly ITitleService titleService;

        public CustomerService(SheCollectionContext context, ITitleService titleService) : base(context)
        {
            this.titleService = titleService;
        }

        public override CustomerTable Create(CustomerTable entity)
        {
            CustomerTable customerTable = context.CustomerTables.Add(entity).Entity;
            context.SaveChanges();
            return customerTable;
        }

        public CustomerTable CreateWithUser(UserTable user)
        {
            CustomerTable customerTable = new CustomerTable()
            {
                CustomerEmail = "test@test.com",
                CustomerName = "UserName",
                User = user,
                CustomerSurname = "UserSurname",
                CustomerPhoneNumber = "0123456789",
                Title = titleService.GetBy(t => t.TitleName == "Mr")[0]
            };

            customerTable = context.CustomerTables.Add(customerTable).Entity;
            context.SaveChanges();
            return customerTable;
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<CustomerTable> GetAll()
        {
            throw new NotImplementedException();
        }

        public override List<CustomerTable> GetBy(Func<CustomerTable, bool> predicate)
        {
            return context.CustomerTables.Include(c => c.User).Include(c => c.User.UserRole).Include(c => c.Title).Where(predicate).ToList();
        }

        public override CustomerTable GetById(int id)
        {
            return context.CustomerTables.Include(c => c.User).Include(c => c.User.UserRole).Include(c => c.Title).FirstOrDefault(c => c.CustomerTableId == id);
        }

        public CustomerTable GetByUserId(int userId)
        {
            return context.CustomerTables.Include(c => c.User).Include(c => c.User.UserRole).Include(c => c.Title).FirstOrDefault(c => c.User.UserTableId == userId);
        }

        public override bool Update(int id, CustomerTable entity)
        {
            CustomerTable customer = GetById(id);

            customer.CustomerPhoneNumber = entity.CustomerPhoneNumber;
            customer.Title = entity.Title;
            customer.CustomerEmail = entity.CustomerEmail;
            customer.CustomerName = entity.CustomerName; 
            customer.CustomerSurname = entity.CustomerSurname;

            context.SaveChanges();

            return true;
        }
    }
}
