using System;
using System.Collections.Generic;

namespace SheCollectionBE.Models
{
    public partial class Discount
    {
        public int DiscountId { get; set; }
        public int DiscountPercentage { get; set; }
        public string DiscountName { get; set; }
    }
}
