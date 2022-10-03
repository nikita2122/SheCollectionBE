using SheCollectionBE.Models;

namespace SheCollectionBE.Services.CartService
{
    public interface ICartService : IService<Cart>
    {
        Cart? getByUserId(int userId);
        void updateTotal(int cartId, decimal amount);
    }
}
