using System;
using System.Collections.Generic;

namespace SheCollectionBE.Models
{
    public partial class CartLine
    {
        public int CartLineId { get; set; }
        public int CartQuantity { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
        public virtual Colour Colour { get; set; }
        public virtual Size Size { get; set; }
    }
}
