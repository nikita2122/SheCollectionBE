using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SheCollectionBE.Models;
using SheCollectionBE.Response_Models;
using SheCollectionBE.Services.CartLineService;
using SheCollectionBE.Services.CartService;
using SheCollectionBE.Services.CustomerService;
using SheCollectionBE.Services.OrderLineService;
using SheCollectionBE.Services.OrderService;
using SheCollectionBE.Services.OrderStatusService;
using SheCollectionBE.Services.ProductService;
using SheCollectionBE.Services.UserService;
using System.Threading.Tasks;

namespace SheCollectionBE.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService orderService;
        private readonly IOrderLineService orderLineService;
        private readonly IOrderStatusService orderStatusService;
        private readonly ICartService cartService;
        private readonly ICartLineService cartLineService;
        private readonly ICustomerService customerService;
        private readonly IUserService userService;
        private readonly IProductService productService;

        public OrderController(IOrderService orderService, IOrderLineService orderLineService, ICartService cartService, ICartLineService cartLineService, IOrderStatusService orderStatusService, ICustomerService customerService, IUserService userService, IProductService productService)
        {
            this.orderService = orderService;
            this.orderLineService = orderLineService;
            this.cartService = cartService;
            this.cartLineService = cartLineService;
            this.orderStatusService = orderStatusService;
            this.customerService = customerService;
            this.userService = userService;
            this.productService = productService;
        }

        [HttpPost("OrderCart")]
        public async Task<IActionResult> OrderCart([FromBody] int userId)
        {
            UserTable user = userService.GetById(userId);

            if (user == null)
                return BadRequest();

            CustomerTable customer = customerService.GetByUserId(userId);

            if (customer == null)
                return BadRequest();

            Cart cart = cartService.getByUserId(userId);

            if (cart == null)
                return BadRequest();

            List<CartLine> cartLines = cartLineService.GetBy(cl => cl.Cart.CartId == cart.CartId);

            OrderTable order = new OrderTable();

            order.Customer = customer;
            order.OrderStatus = orderStatusService.GetBy(os => os.OrderStatusName == "Received")[0];
            order.date = DateTime.Now;
            
            foreach (CartLine cartLine in cartLines)
            {
                order.OrderTotal += cartLine.Product.ProductPrice * cartLine.CartQuantity;
            } 

            OrderTable dbOrder = orderService.Create(order);

            foreach(CartLine cartLine in cartLines)
            {
                OrderLine ol = new OrderLine() {
                    Colour = cartLine.Colour,
                    Size = cartLine.Size,
                    OrderQuantity = cartLine.CartQuantity,
                    Product = cartLine.Product,
                    Order = dbOrder
                };

                productService.ReduceQuantity(cartLine.Product.ProductId, cartLine.CartQuantity);

                orderLineService.Create(ol);
            }

            cartLineService.Clear(cart);

            return new OkResult();
        }
    
        [HttpGet("GetOrdersByUserId")]
        public async Task<IActionResult> GetOrdersByUserId([FromQuery] int userId)
        {
            List<OrderLine> orderLines = orderLineService.GetByUserId(userId);

            Dictionary<int, List<OrderLineResponse>> orderLineResp = new Dictionary<int, List<OrderLineResponse>>();

            foreach (OrderLine line in orderLines)
            {
                if (orderLineResp.ContainsKey(line.Order.OrderTableId))
                {
                    orderLineResp[line.Order.OrderTableId].Add(new OrderLineResponse(line));
                }
                else
                {
                    orderLineResp.Add(line.Order.OrderTableId, new List<OrderLineResponse>());
                    orderLineResp[line.Order.OrderTableId].Add(new OrderLineResponse(line));
                }
            }

            List<OrderResponse> resp = new List<OrderResponse>(orderLineResp.Keys.Count);

            foreach (KeyValuePair<int, List<OrderLineResponse>> pair in orderLineResp)
            {
                OrderTable order = orderService.GetById(pair.Key);

                OrderResponse response = new OrderResponse(order);

                response.OrderLines = pair.Value;

                resp.Add(response);
            }

            return new OkObjectResult(resp);
        }

        [HttpGet("GenerateReport")]
        public async Task<IActionResult> GenerateReport([FromQuery] DateTime date)
        {
            List<OrderLine> orderLines = orderLineService.GetBy(x => x.Order.date.Year == date.Year && x.Order.date.Month == date.Month);

            Dictionary<int, List<OrderLineResponse>> orderLineResp = new Dictionary<int, List<OrderLineResponse>>();

            foreach (OrderLine line in orderLines)
            {
                if (orderLineResp.ContainsKey(line.Order.OrderTableId))
                {
                    orderLineResp[line.Order.OrderTableId].Add(new OrderLineResponse(line));
                }
                else
                {
                    orderLineResp.Add(line.Order.OrderTableId, new List<OrderLineResponse>());
                    orderLineResp[line.Order.OrderTableId].Add(new OrderLineResponse(line));
                }
            }

            List<OrderResponse> resp = new List<OrderResponse>(orderLineResp.Keys.Count);

            foreach (KeyValuePair<int, List<OrderLineResponse>> pair in orderLineResp)
            {
                OrderTable order = orderService.GetById(pair.Key);

                OrderResponse response = new OrderResponse(order);

                response.OrderLines = pair.Value;

                resp.Add(response);
            }

            return new OkObjectResult(resp);
        }
    }
}
