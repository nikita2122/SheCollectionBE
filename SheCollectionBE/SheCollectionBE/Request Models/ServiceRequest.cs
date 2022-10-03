namespace SheCollectionBE.Request_Models
{
    public class ServiceRequest
    {
        public string serviceName { get; set; }
        public string serviceDescription { get; set; }
        public string servicePicture { get; set; }
        public decimal servicePrice { get; set; }
        public int durationMin { get; set; }
        public int durationMax { get; set; }
        public int serviceTypeId { get; set; }
    }
}
