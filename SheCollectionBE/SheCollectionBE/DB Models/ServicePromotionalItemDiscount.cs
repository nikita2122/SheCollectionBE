using System;
using System.Collections.Generic;

namespace SheCollectionBE.Models
{
    public partial class ServicePromotionalItemDiscount
    {
        public int ServicePromotionalItemDiscountId { get; set; }
        public Discount Discount { get; set; }
        public PromotionalItem PromotionalItem { get; set; }
        public ServiceTable Service { get; set; }
    }
}
