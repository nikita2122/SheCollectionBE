using System;
using System.Collections.Generic;

namespace SheCollectionBE.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeeNumber { get; set; }

        public virtual int? EmployeeTypeId { get; set; }
        public virtual EmployeeType? EmployeeType { get; set; }
        public virtual UserTable? User { get; set; }
        public virtual int? UserId { get; set; }
    }
}
