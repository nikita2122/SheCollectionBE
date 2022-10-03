namespace SheCollectionBE.Request_Models
{
    public class ProductRequest
    {
        public string productName { get; set; }
        public string productDescription { get; set; }
        public int[] productSizes { get; set; }
        public int[] productColour { get; set; }
        public int productTypeId { get; set; }
        public int productCategoryId { get; set; }
        public decimal productPrice { get; set; }
        public int quantity { get; set; }
        public string productPicture { get; set; }
    }
}
