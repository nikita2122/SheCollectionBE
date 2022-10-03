using SheCollectionBE.Models;

namespace SheCollectionBE.Services.OrderLineService
{
    public interface IOrderLineService : IService<OrderLine>
    {
        List<OrderLine> GetByUserId(int userId);
    }
}
