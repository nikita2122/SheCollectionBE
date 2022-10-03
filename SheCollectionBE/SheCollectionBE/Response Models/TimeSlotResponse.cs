using SheCollectionBE.Models;

namespace SheCollectionBE.Response_Models
{
    public class TimeSlotResponse
    {
        public int TimeslotId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool available { get;set; }

        public TimeSlotResponse()
        {

        }

        public TimeSlotResponse(Timeslot t, bool a)
        {
            TimeslotId = t.TimeslotId;
            StartTime = t.StartTime.ToUniversalTime().AddMonths(1);
            EndTime = t.EndTime.ToUniversalTime().AddMonths(1);
            available = a;
        }
    }
}
