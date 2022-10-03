using SheCollectionBE.Models;

namespace SheCollectionBE.Response_Models
{
    public class OrderResponse
    {
        public int OrderId { get; set; }
        public decimal OrderTotal { get; set; }
        public virtual OrderStatus? OrderStatus { get; set; }
        public List<OrderLineResponse> OrderLines { get; set; }
        public DateTime date { get; set; }

        public OrderResponse()
        {

        }

        public OrderResponse(OrderTable order)
        {
            OrderId = order.OrderTableId;
            OrderTotal = order.OrderTotal;
            OrderStatus = order.OrderStatus;
            OrderLines = new List<OrderLineResponse>();
            date = order.date;
        }
    }
}
