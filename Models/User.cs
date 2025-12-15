using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_POS.Models
{
    [Table("users")]
    public class User
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("role")]
        public string? Role { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        // -------------------------------
        // OPTIONAL: Relationship (FK)
        // -------------------------------
        public ICollection<Review>? Reviews { get; set; }
    }
}
