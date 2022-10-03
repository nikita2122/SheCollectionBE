using System;
using System.Collections.Generic;

namespace SheCollectionBE.Models
{
    public partial class UserTable
    {
        public int UserTableId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string Picture { get; set; }
        public virtual UserRole UserRole { get; set; }
        public int UserRoleId { get; set; }
    }
}
