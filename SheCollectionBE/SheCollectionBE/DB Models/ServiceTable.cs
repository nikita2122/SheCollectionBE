using System;
using System.Collections.Generic;

namespace SheCollectionBE.Models
{
    public partial class ServiceTable
    {
        public int ServiceTableId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public string ServicePicture { get; set; }
        public decimal ServicePrice { get; set; }
        public float DurationMin { get; set; }
        public float DurationMax { get; set; }
        public ServiceType ServiceType { get; set; }
        public int ServiceTypeId { get; set; }
    }
}
