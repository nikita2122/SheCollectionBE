using System;
using System.Collections.Generic;

namespace SheCollectionBE.Models
{
    public partial class Timeslot
    {
        public int TimeslotId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
