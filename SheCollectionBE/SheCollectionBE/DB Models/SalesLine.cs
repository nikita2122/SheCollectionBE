using System;
using System.Collections.Generic;

namespace SheCollectionBE.Models
{
    public partial class SalesLine
    {
        public int SalesLineId { get; set; }
        public int SalesQuantity { get; set; }

        public Product Product { get; set; }
        public Sale Sales { get; set; }
    }
}
