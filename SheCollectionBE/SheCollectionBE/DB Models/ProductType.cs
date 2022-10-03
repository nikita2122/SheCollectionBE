using System;
using System.Collections.Generic;

namespace SheCollectionBE.Models
{
    public partial class ProductType
    {

        public int ProductTypeId { get; set; }
        public int? ProductCategoryId { get; set; }
        public string ProductTypeName { get; set; }
        public string imgUrl { get; set; }
        public virtual ProductCategory? ProductCategory { get; set; }
    }
}
