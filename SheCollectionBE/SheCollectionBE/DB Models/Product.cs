using System;
using System.Collections.Generic;

namespace SheCollectionBE.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public int ProductTypeId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductBarcode { get; set; }
        public int QuantityAvailable { get; set; }
        public string ProductPicture { get; set; }
        public decimal ProductPrice { get; set; }

        public virtual ProductType ProductType { get; set; }
    }
}
