using SheCollectionBE.Models;

namespace SheCollectionBE.Services.CartLineService
{
    public interface ICartLineService : IService<CartLine>
    {
        List<CartLine> GetByUserId(int userId);
        void Clear(Cart cart);
    }
}
