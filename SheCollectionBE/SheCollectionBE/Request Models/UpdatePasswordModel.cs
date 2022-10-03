namespace SheCollectionBE.Request_Models
{
    public class UpdatePasswordModel
    {
        public string email { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
    }
}
