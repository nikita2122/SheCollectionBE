using SheCollectionBE.Models;

namespace SheCollectionBE.Request_Models
{
    public class ProductResponse
    {
        public int ProductId { get; set; }
        public ProductType ProductType { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductBarcode { get; set; }
        public int QuantityAvailable { get; set; }
        public string ProductPicture { get; set; }
        public decimal ProductPrice { get; set; }
        public List<Size> sizes { get; set; }
        public List<Colour> colours{ get; set; }

        public ProductResponse() { }

        public ProductResponse(ProductSize p)
        {

            ProductId = p.Product.ProductId;
            ProductType = p.Product.ProductType;
            ProductName = p.Product.ProductName;
            ProductDescription = p.Product.ProductDescription;
            ProductBarcode = p.Product.ProductBarcode;
            QuantityAvailable = p.Product.QuantityAvailable;
            ProductPicture = p.Product.ProductPicture;
            ProductPrice = p.Product.ProductPrice;
            sizes = new List<Size>() { p.Size };
            colours = new List<Colour>();
        }

        public ProductResponse(ProductColour p)
        {

            ProductId = p.Product.ProductId;
            ProductType = p.Product.ProductType;
            ProductName = p.Product.ProductName;
            ProductDescription = p.Product.ProductDescription;
            ProductBarcode = p.Product.ProductBarcode;
            QuantityAvailable = p.Product.QuantityAvailable;
            ProductPicture = p.Product.ProductPicture;
            ProductPrice = p.Product.ProductPrice;
            sizes = new List<Size>();
            colours = new List<Colour>() { p.Colour };
        }
    }
}
