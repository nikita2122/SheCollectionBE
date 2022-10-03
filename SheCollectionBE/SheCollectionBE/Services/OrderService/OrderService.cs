using Microsoft.EntityFrameworkCore;
using SheCollectionBE.Context;
using SheCollectionBE.Models;

namespace SheCollectionBE.Services.OrderService
{
    public class OrderService : Service<OrderTable>, IOrderService
    {
        public OrderService(SheCollectionContext context) : base(context)
        {
        }

        public override OrderTable Create(OrderTable entity)
        {
            OrderTable orderTable = context.OrderTables.Add(entity).Entity;
            context.SaveChanges();
            return orderTable;
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<OrderTable> GetAll()
        {
            throw new NotImplementedException();
        }

        public override List<OrderTable> GetBy(Func<OrderTable, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public override OrderTable GetById(int id)
        {
            return context.OrderTables.Include(ot => ot.OrderStatus).Include(ot => ot.Customer).Include(ot => ot.Customer.User).FirstOrDefault(ot => ot.OrderTableId == id);
        }

        public override bool Update(int id, OrderTable entity)
        {
            throw new NotImplementedException();
        }
    }

}
