using SheCollectionBE.Context;
using SheCollectionBE.Models;

namespace SheCollectionBE.Services.ScheduleService
{
    public class ScheduleService : Service<Schedule>, IScheduleService
    {
        public ScheduleService(SheCollectionContext context) : base(context)
        {
        }

        public override Schedule Create(Schedule entity)
        {
            Schedule s = context.Schedules.Add(entity).Entity;
            context.SaveChanges();
            return s;
        }

        public override bool Delete(int id)
        {
            context.Schedules.Remove(GetById(id));
            context.SaveChanges();
            return true;
        }

        public override List<Schedule> GetAll()
        {
            throw new NotImplementedException();
        }

        public override List<Schedule> GetBy(Func<Schedule, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public override Schedule GetById(int id)
        {
            return context.Schedules.FirstOrDefault(x => x.ScheduleId == id);
        }

        public override bool Update(int id, Schedule entity)
        {
            throw new NotImplementedException();
        }
    }
}
