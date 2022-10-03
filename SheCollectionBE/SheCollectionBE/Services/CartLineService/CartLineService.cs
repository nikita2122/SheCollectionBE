using Microsoft.EntityFrameworkCore;
using SheCollectionBE.Context;
using SheCollectionBE.Models;

namespace SheCollectionBE.Services.CartLineService
{
    public class CartLineService : Service<CartLine>, ICartLineService
    {
        public CartLineService(SheCollectionContext context) : base(context)
        {
        }

        public override CartLine Create(CartLine entity)
        {
            CartLine line = context.CartLines.Add(entity).Entity;
            context.SaveChanges();
            return line;
        }

        public override bool Delete(int id)
        {
            context.Remove(GetById(id));
            context.SaveChanges();
            return true;
        }

        public override List<CartLine> GetAll()
        {
            throw new NotImplementedException();
        }

        public override List<CartLine> GetBy(Func<CartLine, bool> predicate)
        {
            return context.CartLines.Include(cl => cl.Product).Include(cl => cl.Colour).Include(cl => cl.Size).Include(cl => cl.Cart).Where(predicate).ToList();
        }

        public override CartLine GetById(int id)
        {
            return context.CartLines.FirstOrDefault(cl => cl.CartLineId == id);
        }

        public List<CartLine> GetByUserId(int userId)
        {
            return context.CartLines
                .Include(cl => cl.Cart)
                .Include(cl => cl.Cart.User)
                .Include(cl => cl.Product)
                .Include(cl => cl.Product.ProductType)
                .Include(cl => cl.Size)
                .Include(cl => cl.Colour)
                .Where(cl => cl.Cart.User.UserTableId == userId)
                .ToList();
        }

        public void Clear(Cart cart)
        {
            context.RemoveRange(context.CartLines.Include(cl => cl.Cart).Where(cl => cl.Cart.CartId == cart.CartId).ToArray());
            context.SaveChanges();
        }

        public override bool Update(int id, CartLine entity)
        {
            throw new NotImplementedException();
        }
    }
}
