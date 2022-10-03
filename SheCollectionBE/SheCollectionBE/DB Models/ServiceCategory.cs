using System;
using System.Collections.Generic;

namespace SheCollectionBE.Models
{
    public partial class ServiceCategory
    {
        public int ServiceCategoryId { get; set; }
        public string ServiceCategoryName { get; set; }
        public string ServiceCategoryDescription { get; set; }
        public string imgUrl { get; set; }
    }
}
