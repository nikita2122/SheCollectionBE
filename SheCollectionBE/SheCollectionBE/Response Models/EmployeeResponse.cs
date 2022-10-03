using SheCollectionBE.Models;

namespace SheCollectionBE.Response_Models
{
    public class EmployeeResponse
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeeNumber { get; set; }

        public virtual EmployeeType? EmployeeType { get; set; }
        public virtual UserResponse? User { get; set; }

        public EmployeeResponse()
        {

        }

        public EmployeeResponse(Employee employee)
        {
            EmployeeId = employee.EmployeeId;
            EmployeeName = employee.EmployeeName;
            EmployeeSurname = employee.EmployeeSurname;
            EmployeeEmail = employee.EmployeeEmail;
            EmployeeNumber = employee.EmployeeNumber;
            EmployeeType = employee.EmployeeType;
            User = new UserResponse(employee.User);

        }
    }
}
