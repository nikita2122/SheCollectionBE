using Microsoft.EntityFrameworkCore;
using SheCollectionBE.Context;
using SheCollectionBE.Models;

namespace SheCollectionBE.Services.EmployeeScheduleService
{
    public class EmployeeScheduleService : Service<EmployeeSchedule>, IEmployeeScheduleService
    {
        public EmployeeScheduleService(SheCollectionContext context) : base(context)
        {
        }

        public override EmployeeSchedule Create(EmployeeSchedule entity)
        {
            EmployeeSchedule es = context.EmployeeSchedules.Add(entity).Entity;
            context.SaveChanges();
            return es;
        }

        public override bool Delete(int id)
        {
            context.EmployeeSchedules.Remove(GetById(id));
            context.SaveChanges();
            return true;
        }

        public override List<EmployeeSchedule> GetAll()
        {
            return context.EmployeeSchedules
                .Include(x => x.Employee)
                .Include(x => x.Employee.User)
                .Include(x => x.Employee.EmployeeType)
                .Include(x => x.Schedule)
                .ToList();
        }

        public override List<EmployeeSchedule> GetBy(Func<EmployeeSchedule, bool> predicate)
        {
            return context.EmployeeSchedules
                           .Include(x => x.Employee)
                           .Include(x => x.Employee.User)
                           .Include(x => x.Employee.EmployeeType)
                           .Include(x => x.Schedule)
                           .Where(predicate)
                           .ToList();
        }

        public override EmployeeSchedule GetById(int id)
        {
            return context.EmployeeSchedules.FirstOrDefault(x => x.EmployeeScheduleId == id);
        }

        public override bool Update(int id, EmployeeSchedule entity)
        {
            throw new NotImplementedException();
        }
    }
}
