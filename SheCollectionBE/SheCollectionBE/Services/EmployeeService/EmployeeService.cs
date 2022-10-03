using Microsoft.EntityFrameworkCore;
using SheCollectionBE.Context;
using SheCollectionBE.Models;

namespace SheCollectionBE.Services.EmployeeService
{
    public class EmployeeService : Service<Employee>, IEmployeeService
    {
        public EmployeeService(SheCollectionContext context) : base(context)
        {
        }

        public override Employee Create(Employee entity)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Employee> GetAll()
        {
            return context.Employees
                .Include(x => x.User)
                .Include(x => x.EmployeeType)
                .ToList();
        }

        public override List<Employee> GetBy(Func<Employee, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public override Employee GetById(int id)
        {
            return context.Employees.Include(x => x.User)
                .Include(x => x.EmployeeType).FirstOrDefault(x => x.EmployeeId == id);
        }

        public override bool Update(int id, Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
