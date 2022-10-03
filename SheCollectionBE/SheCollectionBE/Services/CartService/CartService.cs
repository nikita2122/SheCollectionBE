using Microsoft.EntityFrameworkCore;
using SheCollectionBE.Context;
using SheCollectionBE.Models;

namespace SheCollectionBE.Services.CartService
{
    public class CartService : Service<Cart>, ICartService
    {
        public CartService(SheCollectionContext context) : base(context)
        {
        }

        public override Cart Create(Cart entity)
        {
            Cart cart = context.Carts.Add(entity).Entity;
            context.SaveChanges();
            return cart;
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Cart> GetAll()
        {
            throw new NotImplementedException();
        }

        public override List<Cart> GetBy(Func<Cart, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public override Cart GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Cart? getByUserId(int userId)
        {
            return context.Carts.Include(c => c.User).FirstOrDefault(c => c.User.UserTableId == userId);
        }

        public override bool Update(int id, Cart entity)
        {
            throw new NotImplementedException();
        }

        public void updateTotal(int cartId, decimal amount)
        {
            context.Carts.FirstOrDefault(c => c.CartId == cartId).CartTotal = amount;
        }
    }
}
