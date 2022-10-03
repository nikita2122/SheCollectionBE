namespace SheCollectionBE.Request_Models
{
    public class CartRequestModel
    {
        public int productId { get; set; }
        public int amount { get; set; }
        public int userId { get; set; }
        public int colourId { get; set; }
        public int sizeId { get; set; }
    }
}
