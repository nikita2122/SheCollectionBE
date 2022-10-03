using SheCollectionBE.Models;

namespace SheCollectionBE.Response_Models
{
    public class CustomerResponse
    {
        public int CustomerTableId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhoneNumber { get; set; }

        public virtual Title Title { get; set; }
        public virtual UserResponse User { get; set; }

        public CustomerResponse()
        {

        }

        public CustomerResponse(CustomerTable customer)
        {
            CustomerTableId = customer.CustomerTableId;
            CustomerName = customer.CustomerName;
            CustomerSurname = customer.CustomerSurname;
            CustomerEmail = customer.CustomerEmail;
            CustomerPhoneNumber = customer.CustomerPhoneNumber;
            Title = customer.Title;
            User = new UserResponse(customer.User);

        }
    }
}
