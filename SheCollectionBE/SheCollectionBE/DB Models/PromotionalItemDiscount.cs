using System;
using System.Collections.Generic;

namespace SheCollectionBE.Models
{
    public partial class PromotionalItemDiscount
    {
        public int PromotionalItemDiscountId { get; set; }
        public virtual Discount? Discount { get; set; }
        public virtual PromotionalItem? PromotionalItem { get; set; }
    }
}
