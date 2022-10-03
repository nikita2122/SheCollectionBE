using System;
using System.Collections.Generic;

namespace SheCollectionBE.Models
{
    public partial class ProductColour
    {
        public int ProductColourId { get; set; }
        public virtual Colour Colour { get; set; }
        public virtual Product Product { get; set; }
    }
}
