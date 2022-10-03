using System;
using System.Collections.Generic;

namespace SheCollectionBE.Models
{
    public partial class QuantityOnHand
    {
        public int QuantityOnHandId { get; set; }
        public virtual Product? Product { get; set; }
        public virtual StockTake? StockTake { get; set; }
    }
}
