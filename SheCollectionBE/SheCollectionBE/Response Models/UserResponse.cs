using SheCollectionBE.Models;

namespace SheCollectionBE.Response_Models
{
    public class UserResponse
    {
        public int UserTableId { get; set; }
        public string UserName { get; set; }
        public string Picture { get; set; }
        public virtual UserRole UserRole { get; set; }

        public UserResponse()
        {

        }

        public UserResponse(UserTable user)
        {
            UserTableId = user.UserTableId;
            UserName = user.UserName;
            Picture = user.Picture;
            UserRole = user.UserRole;

        }
    }
}
