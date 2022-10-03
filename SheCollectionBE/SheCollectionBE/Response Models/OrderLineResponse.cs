using SheCollectionBE.Models;

namespace SheCollectionBE.Response_Models
{
    public class OrderLineResponse
    {
        public int OrderQuantity { get; set; }
        public virtual Product Product { get; set; }
        public virtual Colour Colour { get; set; }
        public virtual Size Size { get; set; }

        public OrderLineResponse()
        {

        }

        public OrderLineResponse(OrderLine orderLine)
        {
            OrderQuantity = orderLine.OrderQuantity;
            Product = orderLine.Product;
            Colour = orderLine.Colour;
            Size = orderLine.Size;
        }
    }
}
