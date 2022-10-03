using SheCollectionBE.Models;

namespace SheCollectionBE.Services.ProductService
{
    public interface IProductService : IService<Product>
    {
        List<Product> GetProductByType(int id);
        void ReduceQuantity(int id, int amount);
    }
}
