using System;
using System.Collections.Generic;

namespace SheCollectionBE.Models
{
    public partial class PromotionalItem
    {
        public int PromotionalItemId { get; set; }
        public string PromotionalItemName { get; set; }
        public string PromotionalItemDescription { get; set; }
        public DateTime PromotionStartDate { get; set; }
        public DateTime PromotionEndDate { get; set; }
    }
}
