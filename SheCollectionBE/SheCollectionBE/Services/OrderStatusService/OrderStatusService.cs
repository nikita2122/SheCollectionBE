using SheCollectionBE.Context;
using SheCollectionBE.Models;

namespace SheCollectionBE.Services.OrderStatusService
{
    public class OrderStatusService : Service<OrderStatus>, IOrderStatusService
    {
        public OrderStatusService(SheCollectionContext context) : base(context)
        {
        }

        public override OrderStatus Create(OrderStatus entity)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<OrderStatus> GetAll()
        {
            return context.OrderStatuses.ToList();
        }

        public override List<OrderStatus> GetBy(Func<OrderStatus, bool> func)
        {
            return context.OrderStatuses.Where(func).ToList();
        }

        public override OrderStatus GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(int id, OrderStatus entity)
        {
            throw new NotImplementedException();
        }
    }
}
