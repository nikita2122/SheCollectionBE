using SheCollectionBE.Models;

namespace SheCollectionBE.Response_Models
{
    public class AuthenticatedResponse
    {
        public string? Token { get; set; }
        public UserRole role { get; set; }
        public int userId { get; set; }
    }
}
