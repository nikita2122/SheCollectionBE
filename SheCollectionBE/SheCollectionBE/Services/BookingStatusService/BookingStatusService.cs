using SheCollectionBE.Context;
using SheCollectionBE.Models;

namespace SheCollectionBE.Services.BookingStatusService
{
    public class BookingStatusService : Service<BookingStatus>, IBookingStatusService
    {
        public BookingStatusService(SheCollectionContext context) : base(context)
        {
        }

        public override BookingStatus Create(BookingStatus entity)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<BookingStatus> GetAll()
        {
            throw new NotImplementedException();
        }

        public override List<BookingStatus> GetBy(Func<BookingStatus, bool> predicate)
        {
            return context.BookingStatuses.Where(predicate).ToList();
        }

        public override BookingStatus GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(int id, BookingStatus entity)
        {
            throw new NotImplementedException();
        }
    }
}
