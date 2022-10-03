using System;
using System.Collections.Generic;

namespace SheCollectionBE.Models
{
    public partial class ProductSize
    {
        public int ProductSizeId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Size Size { get; set; }
    }
}
