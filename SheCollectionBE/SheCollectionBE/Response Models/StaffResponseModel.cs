using SheCollectionBE.Models;

namespace SheCollectionBE.Response_Models
{
    public class StaffResponseModel
    {
        public int employeeId { get; set; }
        public string employeeName { get; set; }
        public string employeeSurname { get; set; }
        public string employeeEmail { get; set; }
        public string employeeNumber { get; set; }
        public EmployeeType employeeType { get; set; }
        public UserResponse user { get; set; }
        public List<Schedule> schedule { get; set; }

        public StaffResponseModel()
        {

        }

        public StaffResponseModel(Employee e)
        {
            employeeId = e.EmployeeId;
            employeeName = e.EmployeeName;
            employeeSurname = e.EmployeeSurname;
            employeeEmail = e.EmployeeEmail;
            employeeNumber = e.EmployeeNumber;
            employeeType = e.EmployeeType;
            user = new UserResponse(e.User);
            schedule = new List<Schedule>();
        }
    }
}
