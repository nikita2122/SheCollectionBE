using System;
using System.Collections.Generic;

namespace SheCollectionBE.Models
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int? BookingId { get; set; }
        public int? PaymentTypeId { get; set; }
        public int? PaymentStatusId { get; set; }
        public int? OrderId { get; set; }
        public int? SalesId { get; set; }
        public decimal PaymentAmount { get; set; }
        public string PaymentReference { get; set; }

        public virtual Booking? Booking { get; set; }
        public virtual OrderTable? Order { get; set; }
        public virtual PaymentStatus? PaymentStatus { get; set; }
        public virtual PaymentType? PaymentType { get; set; }
        public virtual Sale? Sales { get; set; }
    }
}
