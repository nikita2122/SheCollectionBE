using SheCollectionBE.Context;
using SheCollectionBE.Models;

namespace SheCollectionBE.Services.TimeSlotService
{
    public class TimeSlotService : Service<Timeslot>, ITimeSlotService
    {
        public TimeSlotService(SheCollectionContext context) : base(context)
        {
        }

        public override Timeslot Create(Timeslot entity)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Timeslot> GetAll()
        {
            return context.Timeslots.ToList();
        }

        public override List<Timeslot> GetBy(Func<Timeslot, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public override Timeslot GetById(int id)
        {
            return context.Timeslots.FirstOrDefault(x => x.TimeslotId == id);
        }

        public override bool Update(int id, Timeslot entity)
        {
            throw new NotImplementedException();
        }
    }
}
