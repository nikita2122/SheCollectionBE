using System;
using System.Collections.Generic;

namespace SheCollectionBE.Models
{
    public partial class Cart
    {
        public int CartId { get; set; }
        public decimal CartTotal { get; set; }
        public UserTable User { get; set; }
    }
}
