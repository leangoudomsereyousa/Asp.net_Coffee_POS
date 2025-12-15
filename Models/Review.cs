using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Coffee_POS.Models
{
    public class Review
    {
        [Key]
        public long Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(User))]
        public long UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Rating { get; set; }

        [Required]
        public string Subject { get; set; }

        // Relationship
        public User User { get; set; }

    }
}
