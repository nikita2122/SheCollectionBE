using System;
using System.Collections.Generic;

namespace SheCollectionBE.Models
{
    public partial class OrderTable
    {
        public int OrderTableId { get; set; }
        public decimal OrderTotal { get; set; }
        public virtual CustomerTable? Customer { get; set; }
        public virtual OrderStatus? OrderStatus { get; set; }
        public DateTime date { get; set; } = new DateTime();
    }
}
