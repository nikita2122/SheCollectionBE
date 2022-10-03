using SheCollectionBE.Models;

namespace SheCollectionBE.Response_Models
{
    public class CartResponse
    {
        public int CartId { get; set; }
        public decimal CartTotal { get; set; }
        public int UserId { get; set; }

        public CartResponse()
        {

        }

        public CartResponse(Cart cart)
        {
            CartId = cart.CartId;
            CartTotal = cart.CartTotal;
            UserId = cart.User.UserTableId;
        }
    }
}
