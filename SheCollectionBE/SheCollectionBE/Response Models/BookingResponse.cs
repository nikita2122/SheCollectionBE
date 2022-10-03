using SheCollectionBE.Models;

namespace SheCollectionBE.Response_Models
{
    public class BookingResponse
    {
        public int BookingId { get; set; }

        public string BookingDescription { get; set; } = null!;

        public virtual BookingStatus? BookingStatus { get; set; }
        public virtual CustomerResponse? Customer { get; set; }
        public virtual EmployeeResponse? Employee { get; set; }
        public virtual Schedule? Schedule { get; set; }
        public virtual Timeslot? Timeslot { get; set; }
        public virtual ServiceTable ServiceTable { get; set; }

        public BookingResponse()
        {

        }

        public BookingResponse(Booking booking)
        {
            BookingId = booking.BookingId;
            BookingDescription = booking.BookingDescription;
            BookingStatus = booking.BookingStatus;
            Customer = new CustomerResponse(booking.Customer);
            Employee = new EmployeeResponse(booking.Employee);
            Schedule = booking.Schedule;
            Timeslot = booking.Timeslot;
            ServiceTable = booking.ServiceTable;

        }
    }
}
