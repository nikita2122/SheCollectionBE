using System;
using System.Collections.Generic;

namespace SheCollectionBE.Models
{
    public partial class ScheduleTimeslot
    {
        public int ScheduleTimeslotId { get; set; }

        public Schedule Schedule { get; set; }
        public Timeslot Timeslot { get; set; }
    }
}
