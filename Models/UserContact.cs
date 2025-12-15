using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_POS.Models
{
    [Table("user_contacts")] // table name (optional but recommended)
    public class UserContact
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("name")]
        [Required]
        public string Name { get; set; }

        [Column("phone")]
        [Required]
        public string Phone { get; set; }

        [Column("inquiry_type")]
        [Required]
        public string InquiryType { get; set; }

        [Column("message")]
        [Required]
        public string Message { get; set; }

        [Column("user_id")]
        public long? UserId { get; set; }

        // timestamps (Laravel equivalent)
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        // Relationship (optional)
        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
