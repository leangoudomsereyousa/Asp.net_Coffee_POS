using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_POS.Models
{
    [Table("reviews")] 
    public class Review
    {
        [Key]
        public int Id { get; set; }

        public int? User_Id { get; set; }

        public string? Name { get; set; }

        public int Rating { get; set; }

        public string? Subject { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
