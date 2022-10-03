using System;
using System.Collections.Generic;

namespace SheCollectionBE.Models
{
    public partial class ProductPromotionalItemDiscount
    {
        public int ProductPromotionalItemDiscountId { get; set; }
        public virtual Discount? Discount { get; set; }
        public virtual Product? Product { get; set; }
        public virtual PromotionalItem? PromotionalItem { get; set; }
    }
}
