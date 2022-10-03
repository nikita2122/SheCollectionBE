using Microsoft.AspNetCore.Mvc;
using SheCollectionBE.Models;
using SheCollectionBE.Request_Models;
using SheCollectionBE.Response_Models;
using SheCollectionBE.Services.CartLineService;
using SheCollectionBE.Services.CartService;
using SheCollectionBE.Services.ColourService;
using SheCollectionBE.Services.ProductService;
using SheCollectionBE.Services.SizeService;
using SheCollectionBE.Services.UserService;

namespace SheCollectionBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;
        private readonly ICartLineService cartLineService;
        private readonly IUserService userService;
        private readonly IProductService productService;
        private readonly IColourService colourService;
        private readonly ISizeService sizeService;

        public CartController(ICartService cartService, ICartLineService cartLineService, IUserService userService, IProductService productService, IColourService colourService, ISizeService sizeService)
        {
            this.cartService = cartService;
            this.cartLineService = cartLineService;
            this.userService = userService;
            this.productService = productService;
            this.colourService = colourService;
            this.sizeService = sizeService;
        }

        [HttpPost("AddToCart")]
        public async Task<IActionResult> AddToCart(CartRequestModel request)
        {
            Cart cart = cartService.getByUserId(request.userId);

            if (cart == null)
            {
                UserTable user = userService.GetById(request.userId);

                if (user == null)
                    return new BadRequestResult();

                Cart newCart = new Cart()
                {
                    CartTotal = 0,
                    User = user,
                };
                cart = cartService.Create(newCart);
            }

            Product product = productService.GetById(request.productId);
            Colour colour = colourService.GetById(request.colourId);
            Size size = sizeService.GetById(request.sizeId);

            if (product == null || colour == null || size == null)
                return new BadRequestResult();

            CartLine line = new CartLine()
            {
                Cart = cart,
                Product = product,
                CartQuantity = request.amount,
                Colour = colour,
                Size = size,
            };

            return new OkObjectResult(cartLineService.Create(line));
        }

        [HttpGet("GetCartLines")]
        public async Task<IActionResult> GetCartLines([FromQuery] int userId)
        {
            return new OkObjectResult(CartLineListToResponse(cartLineService.GetByUserId(userId)));
        }
        
        [HttpGet("ClearCart")]
        public async Task<IActionResult> ClearCart([FromQuery] int userId)
        {
            Cart cart = cartService.getByUserId(userId);

            if (cart == null)
                return new BadRequestResult();

            cartLineService.Clear(cart);

            return new OkResult();
        }
        
        [HttpDelete("DeleteCartLine")]
        public async Task<IActionResult> DeleteCartLine([FromQuery] int lineId)
        {
            return new OkObjectResult(cartLineService.Delete(lineId));
        }

        private List<CartLineResponse> CartLineListToResponse(List<CartLine> lines)
        {
            List<CartLineResponse> resp = new List<CartLineResponse>(lines.Count);
            foreach (CartLine line in lines)
            {
                resp.Add(new CartLineResponse(line));
            }
            return resp;
        }
    }
}
