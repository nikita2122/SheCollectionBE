using System;
using System.Collections.Generic;

namespace SheCollectionBE.Models
{
    public partial class ProductCategory
    {
        public int ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
        public string ProductCategoryDescription { get; set; }
        public string imgUrl { get; set; }
    }
}
