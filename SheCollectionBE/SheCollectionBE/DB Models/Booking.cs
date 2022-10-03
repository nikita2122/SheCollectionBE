using System;
using System.Collections.Generic;

namespace SheCollectionBE.Models
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int? CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public int? ScheduleId { get; set; }
        public int? TimeslotId { get; set; }
        public int? BookingStatusId { get; set; }
        public string BookingDescription { get; set; } = null!;

        public virtual BookingStatus? BookingStatus { get; set; }
        public virtual CustomerTable? Customer { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual Schedule? Schedule { get; set; }
        public virtual Timeslot? Timeslot { get; set; }
        public virtual ServiceTable ServiceTable { get; set; }
    }
}
