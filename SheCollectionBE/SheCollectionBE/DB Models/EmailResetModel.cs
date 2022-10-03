using System.ComponentModel.DataAnnotations;

namespace SheCollectionBE.DB_Models
{
    public class EmailResetModel
    {
        [Key]
        [Required]
        public int EmailResetId { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Code { get; set; }
    }

}
