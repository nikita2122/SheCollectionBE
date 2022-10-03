namespace SheCollectionBE.Request_Models
{
    public class MakeBookingRequest
    {
        public int serviceId { get; set; }
        public int staffMemberId { get; set; }
        public int userId { get; set; }
        public int timeSlotId { get; set; }
        public DateTime date { get; set; }
    }
}
