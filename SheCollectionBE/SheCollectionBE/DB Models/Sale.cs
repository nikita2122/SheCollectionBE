using System;
using System.Collections.Generic;

namespace SheCollectionBE.Models
{
    public partial class Sale
    {
        public int SaleId { get; set; }
        public decimal SalesAmount { get; set; }

        public SalesStatus SalesStatus { get; set; }
    }
}
