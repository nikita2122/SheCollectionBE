using SheCollectionBE.Models;

namespace SheCollectionBE.Services.ProductColourService
{
    public interface IProductColourService: IService<ProductColour>
    {
        List<ProductColour> GetByProductId(int id);
    }
}
