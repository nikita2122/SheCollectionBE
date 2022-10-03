namespace SheCollectionBE.Request_Models
{
    public class ResetPasswordModel
    {
        public string newPassword { get; set; }
        public string email { get; set; }
        public string code { get; set; }
    }
}
