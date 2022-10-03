using SheCollectionBE.Models;

namespace SheCollectionBE.Services.ProductTypeService
{
    public interface IProductTypeService : IService<ProductType>
    {
        List<ProductType> GetProductTypesByCategory(int categoryId);
    }
}
