using System;
using System.Collections.Generic;

namespace SheCollectionBE.Models
{
    public partial class CustomerTable
    {
        public int CustomerTableId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhoneNumber { get; set; }

        public virtual Title? Title { get; set; }
        public virtual UserTable? User { get; set; }
    }
}
