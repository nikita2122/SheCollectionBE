using Microsoft.EntityFrameworkCore;
using SheCollectionBE.Context;
using SheCollectionBE.Models;

namespace SheCollectionBE.Services.BookingService
{
    public class BookingService : Service<Booking>, IBookingService
    {
        public BookingService(SheCollectionContext context) : base(context)
        {
        }

        public override Booking Create(Booking entity)
        {
            Booking booking = context.Bookings.Add(entity).Entity;
            context.SaveChanges();
            return booking;
        }

        public override bool Delete(int id)
        {
            context.Bookings.Remove(GetById(id));
            context.SaveChanges();
            return true;
        }

        public override List<Booking> GetAll()
        {
            return context.Bookings.ToList();
        }

        public override List<Booking> GetBy(Func<Booking, bool> predicate)
        {
            return context.Bookings
                .Include(b => b.Schedule)
                .Include(b => b.BookingStatus)
                .Include(b => b.Customer)
                .Include(b => b.Customer.User)
                .Include(b => b.ServiceTable)
                .Include(b => b.Timeslot)
                .Include(b => b.Employee)
                .Include(b => b.Employee.User)
                .Where(predicate)
                .ToList();
        }

        public override Booking GetById(int id)
        {
            return context.Bookings
                            .Include(b => b.Schedule)
                            .Include(b => b.BookingStatus)
                            .Include(b => b.Customer)
                            .Include(b => b.Customer.User)
                            .Include(b => b.ServiceTable)
                            .Include(b => b.Timeslot)
                            .Include(b => b.Employee)
                            .Include(b => b.Employee.User)
                            .FirstOrDefault(x => x.BookingId == id);
        }

        public override bool Update(int id, Booking entity)
        {
            throw new NotImplementedException();
        }
    }
}
