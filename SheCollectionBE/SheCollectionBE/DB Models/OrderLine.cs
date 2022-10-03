using System;
using System.Collections.Generic;

namespace SheCollectionBE.Models
{
    public partial class OrderLine
    {
        public int OrderLineId { get; set; }
        public int OrderQuantity { get; set; }
        public virtual OrderTable Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual Colour Colour { get; set; }
        public virtual Size Size { get; set; }

    }
}
