using System;
using System.Collections.Generic;

namespace SheCollectionBE.Models
{
    public partial class EmployeeSchedule
    {
        public int EmployeeScheduleId { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual Schedule? Schedule { get; set; }
    }
}
