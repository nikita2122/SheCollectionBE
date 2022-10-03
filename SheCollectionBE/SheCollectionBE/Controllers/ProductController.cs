using Microsoft.AspNetCore.Mvc;
using SheCollectionBE.Models;
using SheCollectionBE.Request_Models;
using SheCollectionBE.Services.CategoryService;
using SheCollectionBE.Services.ColourService;
using SheCollectionBE.Services.ProductColourService;
using SheCollectionBE.Services.ProductService;
using SheCollectionBE.Services.ProductSizeService;
using SheCollectionBE.Services.ProductTypeService;
using SheCollectionBE.Services.SizeService;
using System.Collections.Generic;
using System.Text;

namespace SheCollectionBE.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService productService;
        private readonly ISizeService sizeService;
        private readonly IColourService colourService;
        private readonly IProductSizeService productSizeService;
        private readonly IProductColourService productColourService;
        private readonly ICategoryService categoryService;
        private readonly IProductTypeService productTypeService;

        public ProductController(IProductService productService, ISizeService sizeService, IColourService colourService, IProductSizeService productSizeService, IProductColourService productColourService, ICategoryService categoryService, IProductTypeService productTypeService)
        {
            this.productService = productService;
            this.sizeService = sizeService;
            this.colourService = colourService;
            this.productSizeService = productSizeService;
            this.productColourService = productColourService;
            this.categoryService = categoryService;
            this.productTypeService = productTypeService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            List<ProductSize> productSizes = productSizeService.GetAll();
            List<ProductColour> productColours = productColourService.GetAll();

            return new OkObjectResult(formatProductResponse(productColours, productSizes));
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            List<ProductSize> productSizes = productSizeService.GetByProductId(id);
            List<ProductColour> productColours = productColourService.GetByProductId(id);

            if (productSizes.Count == 0 && productColours.Count == 0)
                return NotFound();

            return new OkObjectResult(formatProductResponse(productColours, productSizes)[0]);
        }

        [HttpGet("GetProductSizes")]
        public async Task<IActionResult> GetProductSizes()
        {
            return new OkObjectResult(sizeService.GetAll());
        }

        [HttpGet("GetProductColours")]
        public async Task<IActionResult> GetProductColours()
        {
            return new OkObjectResult(colourService.GetAll());
        }

        [HttpGet("GetProductCategories")]
        public async Task<IActionResult> GetProductCategories()
        {
            return new OkObjectResult(categoryService.GetAll());
        }

        [HttpGet("GetProductTypes")]
        public async Task<IActionResult> GetProductTypes()
        {
            return new OkObjectResult(productTypeService.GetAll());
        }

        [HttpGet("GetByType")]
        public async Task<IActionResult> GetProductTypes([FromQuery] int id)
        {
            return new OkObjectResult(productService.GetProductByType(id));
        }

        [HttpGet("GetProductTypesByCategory")]
        public async Task<IActionResult> GetProductTypesByCategory([FromQuery] int categoryId)
        {
            return new OkObjectResult(productTypeService.GetProductTypesByCategory(categoryId));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ProductRequest product)
        {
            if (product == null)
                return BadRequest();

            ProductType pt = productTypeService.GetById(product.productTypeId);

            if (pt == null)
                return BadRequest();

            Product prod = new Product()
            {
                ProductName = product.productName,
                ProductDescription = product.productDescription,
                ProductBarcode = GenerateBarcode(),
                QuantityAvailable = product.quantity,
                ProductPicture = product.productPicture,
                ProductPrice = product.productPrice,
                ProductType = pt,
            };

            Product newProduct = productService.Create(prod);

            foreach (int pc in product.productColour)
            {
                ProductColour productColour = new ProductColour();

                productColour.Product = newProduct;
                productColour.Colour = colourService.GetById(pc);

                productColourService.Create(productColour);
            }

            foreach (int ps in product.productSizes)
            {
                ProductSize productSize = new ProductSize();

                productSize.Product = newProduct;
                productSize.Size = sizeService.GetById(ps);

                productSizeService.Create(productSize);
            }

            return new CreatedResult("Create", newProduct);
        }

        private ProductResponse[] formatProductResponse(List<ProductColour> productColours, List<ProductSize> productSizes)
        {
            Dictionary<int, ProductResponse> respDict = new Dictionary<int, ProductResponse>();

            foreach (ProductSize p in productSizes)
            {
                if (respDict.ContainsKey(p.Product.ProductId))
                {
                    respDict[p.Product.ProductId].sizes.Add(p.Size);
                }
                else
                {
                    ProductResponse resp = new ProductResponse(p);

                    respDict.Add(p.Product.ProductId, resp);
                }
            }

            foreach (ProductColour p in productColours)
            {
                if (respDict.ContainsKey(p.Product.ProductId))
                {
                    respDict[p.Product.ProductId].colours.Add(p.Colour);
                }
                else
                {
                    ProductResponse resp = new ProductResponse(p);

                    respDict.Add(p.Product.ProductId, resp);
                }
            }

            return respDict.Values.ToArray();
        }

        private string GenerateBarcode(int length = 7)
        {
            // creating a StringBuilder object()
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }

            return str_build.ToString();
        }
    }
}
