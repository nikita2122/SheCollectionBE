using SheCollectionBE.Models;

namespace SheCollectionBE.Services.ProductSizeService
{
    public interface IProductSizeService : IService<ProductSize>
    {
        List<ProductSize> GetByProductId(int id);
    }
}
