using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SheCollectionBE.Context;
using SheCollectionBE.Models;
using SheCollectionBE.Request_Models;
using SheCollectionBE.Response_Models;
using SheCollectionBE.Services.BookingService;
using SheCollectionBE.Services.BookingStatusService;
using SheCollectionBE.Services.CustomerService;
using SheCollectionBE.Services.EmailService;
using SheCollectionBE.Services.EmployeeScheduleService;
using SheCollectionBE.Services.EmployeeService;
using SheCollectionBE.Services.EmployeeTypeService;
using SheCollectionBE.Services.ScheduleService;
using SheCollectionBE.Services.ServiceCategoryService;
using SheCollectionBE.Services.ServicesService;
using SheCollectionBE.Services.ServiceTypeService;
using SheCollectionBE.Services.TimeSlotService;

namespace SheCollectionBE.Controllers
{
    public class BookingController : BaseController
    {
        private readonly SheCollectionContext context;
        private readonly IBookingService bookingService;
        private readonly ITimeSlotService timeSlotService;
        private readonly IServiceCategoryService serviceCategoryService;
        private readonly IServiceTypeService serviceTypeService;
        private readonly IServicesService servicesService;
        private readonly IEmployeeService employeeService;
        private readonly IEmployeeScheduleService employeeScheduleService;
        private readonly IEmployeeTypeService employeeTypeService;
        private readonly IScheduleService scheduleService;
        private readonly ICustomerService customerService;
        private readonly IBookingStatusService bookingStatusService;
        private readonly IEmailService emailService;

        public BookingController(SheCollectionContext context,IBookingService bookingService, ITimeSlotService timeSlotService, IServiceCategoryService serviceCategoryService, IServiceTypeService serviceTypeService, IServicesService servicesService, IEmployeeService employeeService, IEmployeeScheduleService employeeScheduleService, IEmployeeTypeService employeeTypeService, IScheduleService scheduleService, ICustomerService customerService, IBookingStatusService bookingStatusService, IEmailService emailService)
        {
            this.context = context;
            this.bookingService = bookingService;
            this.timeSlotService = timeSlotService;
            this.serviceCategoryService = serviceCategoryService;
            this.serviceTypeService = serviceTypeService;
            this.servicesService = servicesService;
            this.employeeService = employeeService;
            this.employeeScheduleService = employeeScheduleService;
            this.employeeTypeService = employeeTypeService;
            this.scheduleService = scheduleService;
            this.customerService = customerService;
            this.bookingStatusService = bookingStatusService;
            this.emailService = emailService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return new OkObjectResult(bookingService.GetAll());
        }

        [HttpGet("GetTimeSlots")]
        public async Task<IActionResult> GetTimeSlots([FromQuery] DateTime date)
        {
            date = date.ToLocalTime().AddMonths(1);
            List<Booking> bookings = bookingService.GetBy(b => b.Schedule.Date == date);
            List<Timeslot> oldtimeslots = timeSlotService.GetAll();

            

            var timeslots = CreateSlots(date).ToList();

            timeslots= timeslots.Where(x => oldtimeslots.All(y => y.StartTime != x.StartTime)).ToList();
            if (timeslots.Any())
            {
                await context.Timeslots.AddRangeAsync(timeslots);
                await context.SaveChangesAsync(); 
            }
            List<TimeSlotResponse> resp = new List<TimeSlotResponse>(oldtimeslots.Where(x => x.StartTime.DayOfYear == date.DayOfYear).Count());

            foreach (Timeslot t in oldtimeslots.Where(x=>x.StartTime.DayOfYear == date.DayOfYear))
            {
                if (bookings.Where(b => b.Timeslot.TimeslotId == t.TimeslotId).ToArray().Length > 0)
                    resp.Add(new TimeSlotResponse(t, false));
                else
                    resp.Add(new TimeSlotResponse(t, true));
            }

            return Ok(resp);
        }

        [HttpGet("GetByUserId")]
        public async Task<IActionResult> GetByUserId([FromQuery] int userId)
        {
            List<Booking> bookings = bookingService.GetBy(b => b.Customer.User.UserTableId == userId);
            List<BookingResponse> resp = new List<BookingResponse>(bookings.Count);

            foreach (Booking booking in bookings)
            {
                resp.Add(new BookingResponse(booking));
            }

            return Ok(resp);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int bookingId)
        {
            Booking booking = bookingService.GetById(bookingId);

            if (booking == null)
                return NotFound();

            BookingResponse resp = new BookingResponse(booking);

            return Ok(resp);
        }
        [HttpGet("GetSlotById")]
        public async Task<IActionResult> GetSlotById([FromQuery] int id)
        {
            var booking = timeSlotService.GetById(id);

            if (booking == null)
                return NotFound();

            var resp = new TimeSlotResponse(booking, true);

            return Ok(resp);
        }

        [HttpPost("MakeBooking")]
        public async Task<IActionResult> MakeBooking([FromBody] MakeBookingRequest model)
        {
            Employee emp = employeeService.GetById(model.staffMemberId);
            ServiceTable service = servicesService.GetById(model.serviceId);
            Timeslot timeslot = timeSlotService.GetById(model.timeSlotId);
            CustomerTable customer = customerService.GetByUserId(model.userId);
            BookingStatus bookingStatus = bookingStatusService.GetBy(x => x.BookingStatusName == "Upcoming")[0];

            Schedule schedule = scheduleService.Create(new Schedule() { Date = model.date });

            Booking booking = new Booking()
            {
                BookingDescription = "",
                BookingStatus = bookingStatus,
                Customer = customer,
                Employee = emp,
                Schedule = schedule,
                Timeslot = timeslot,
                ServiceTable = service,
            };

            string emailBody = $"Dear {customer.CustomerName},\n" +
                $"\n" +
                $"Your booking has been confirmed and it's details are as follows:\n" +
                $"Service - {service.ServiceName}\n" +
                $"Date - {model.date.ToString("dd MMMM yyyy")}\n" +
                $"Time - {timeslot.StartTime.ToString("HH:mm")} - {timeslot.EndTime.ToString("HH:mm")}\n" +
                $"Staff Member - {emp.EmployeeName}\n" +
                $"\n" +
                $"sheCollection Mail & Beauty Bar.\n";

            emailService.SendEmail(emailBody,
                "SheCollection - Booking confirmation",
                customer.CustomerEmail);

            return Ok(bookingService.Create(booking));
        }

        [HttpGet("Cancel")]
        public async Task<IActionResult> Cancel([FromQuery] int bookingId)
        {
            Booking booking = bookingService.GetById(bookingId);

            if (booking == null)
                return NotFound();

            bookingService.Delete(bookingId);
            scheduleService.Delete(booking.Schedule.ScheduleId);

            return Ok();
        }

        private Timeslot[] CreateSlots(DateTime d)
        {
            var slots = new Timeslot[7];
            for (int i = 1; i < 8; i++)
            {
                var start = new DateTime(d.Year, d.Month, d.Day, i + 6, 0, 0);
                var end = new DateTime(d.Year, d.Month, d.Day, i + 8, 0, 0);
                slots[i - 1] = new Timeslot() {TimeslotId=default, EndTime = end, StartTime = start };
            }
            return slots;
        }
    }
}
