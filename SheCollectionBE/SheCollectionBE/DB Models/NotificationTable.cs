using System;
using System.Collections.Generic;

namespace SheCollectionBE.Models
{
    public partial class NotificationTable
    {
        public int NotificationTableId { get; set; }
        public string NotificationDescription { get; set; }
        public string NotificationName { get; set; }

        public virtual NotificationType? NotificationType { get; set; }
        public virtual UserTable? User { get; set; }
    }
}
