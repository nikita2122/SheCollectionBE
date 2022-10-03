using System;
using System.Collections.Generic;

namespace SheCollectionBE.Models
{
    public partial class ServiceType
    {
        public int ServiceTypeId { get; set; }
        public int ServiceCategoryId { get; set; }
        public string ServiceTypeName { get; set; }
        public string imgUrl { get; set; }
        public virtual ServiceCategory ServiceCategory { get; set; }
    }
}
