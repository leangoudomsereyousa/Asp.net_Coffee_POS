using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_POS.Models
{
    [Table("user_contacts")] 
    public class UserContact
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Phone { get; set; }

        public string? Inquiry_Type { get; set; }

        public string? Message { get; set; }

        public int? User_Id { get; set; }
    }
}
