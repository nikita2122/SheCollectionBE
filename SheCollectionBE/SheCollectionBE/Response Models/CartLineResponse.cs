using SheCollectionBE.Models;

namespace SheCollectionBE.Response_Models
{
    public class CartLineResponse
    {
        public int CartLineId { get; set; }
        public int CartQuantity { get; set; }

        public virtual CartResponse Cart { get; set; }
        public virtual Product Product { get; set; }
        public virtual Colour Colour { get; set; }
        public virtual Size Size { get; set; }

        public CartLineResponse()
        {

        }

        public CartLineResponse(CartLine line)
        {
            CartLineId = line.CartLineId;
            CartQuantity = line.CartQuantity;
            Cart = new CartResponse(line.Cart);
            Product = line.Product;
            Colour = line.Colour;
            Size = line.Size;
        }
    }
}
