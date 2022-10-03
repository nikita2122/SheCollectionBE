using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SheCollectionBE.Models;
using SheCollectionBE.Response_Models;
using SheCollectionBE.Services.EmployeeScheduleService;
using SheCollectionBE.Services.EmployeeService;
using SheCollectionBE.Services.EmployeeTypeService;
using SheCollectionBE.Services.ScheduleService;

namespace SheCollectionBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : BaseController
    {
        private readonly IEmployeeService employeeService;
        private readonly IEmployeeScheduleService employeeScheduleService;
        private readonly IEmployeeTypeService employeeTypeService;
        private readonly IScheduleService scheduleService;

        public StaffController(IEmployeeService employeeService, IEmployeeScheduleService employeeScheduleService, IEmployeeTypeService employeeTypeService, IScheduleService scheduleService)
        {
            this.employeeService = employeeService;
            this.employeeScheduleService = employeeScheduleService;
            this.employeeTypeService = employeeTypeService;
            this.scheduleService = scheduleService;
        }

        [HttpGet("GetStaffMembers")]
        public async Task<IActionResult> GetStaffMembers()
        {
            List<EmployeeSchedule> empSchedules = employeeScheduleService.GetAll();
            List<Employee> emps = employeeService.GetAll();

            return Ok(formatResponse(emps, empSchedules));
        }
        
        [HttpGet("GetStaffMemberById")]
        public async Task<IActionResult> GetStaffMemberById([FromQuery] int id)
        {
            return Ok(employeeService.GetById(id));
        }


        private List<StaffResponseModel> formatResponse(List<Employee> emps, List<EmployeeSchedule> empSchedules)
        {
            Dictionary<int, StaffResponseModel> respDict = new Dictionary<int, StaffResponseModel>();

            foreach (Employee e in emps)
            {
                StaffResponseModel resp = new StaffResponseModel(e);

                respDict.Add(e.EmployeeId, resp);

            }

            foreach (EmployeeSchedule e in empSchedules)
            {
                if (respDict.ContainsKey(e.Employee.EmployeeId))
                {
                    respDict[e.Employee.EmployeeId].schedule.Add(e.Schedule);
                }
            }

            return respDict.Values.ToList();
        }
    }

}
