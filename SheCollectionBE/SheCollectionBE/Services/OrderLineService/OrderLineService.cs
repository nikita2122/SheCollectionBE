using Microsoft.EntityFrameworkCore;
using SheCollectionBE.Context;
using SheCollectionBE.Models;

namespace SheCollectionBE.Services.OrderLineService
{
    public class OrderLineService : Service<OrderLine>, IOrderLineService
    {
        public OrderLineService(SheCollectionContext context) : base(context)
        {
        }

        public override OrderLine Create(OrderLine entity)
        {
            OrderLine orderLine = context.OrderLines.Add(entity).Entity;
            context.SaveChanges();
            return orderLine;
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<OrderLine> GetAll()
        {
            throw new NotImplementedException();
        }

        public override List<OrderLine> GetBy(Func<OrderLine, bool> predicate)
        {
            return context.OrderLines
                           .Include(ol => ol.Order)
                           .Include(ol => ol.Product)
                           .Include(ol => ol.Product.ProductType)
                           .Include(ol => ol.Product.ProductType.ProductCategory)
                           .Include(ol => ol.Colour)
                           .Include(ol => ol.Size)
                           .Include(ol => ol.Order.Customer)
                           .Include(ol => ol.Order.Customer.User)
                           .Where(predicate)
                           .ToList();
        }

        public override OrderLine GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<OrderLine> GetByUserId(int userId)
        {
            return context.OrderLines
                .Include(ol => ol.Order)
                .Include(ol => ol.Product)
                .Include(ol => ol.Product.ProductType)
                .Include(ol => ol.Product.ProductType.ProductCategory)
                .Include(ol => ol.Colour)
                .Include(ol => ol.Size)
                .Include(ol => ol.Order.Customer)
                .Include(ol => ol.Order.Customer.User)
                .Where(ol => ol.Order.Customer.User.UserTableId == userId)
                .ToList();
        }

        public override bool Update(int id, OrderLine entity)
        {
            throw new NotImplementedException();
        }
    }
}
