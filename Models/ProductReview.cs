using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_POS.Models
{
    [Table("product_reviews")]
    public class ProductReview
    {
        [Key]
        public long Id { get; set; }

        [Column("product_id")]
        public long ProductId { get; set; }

        [Column("rating")]
        public int Rating { get; set; } // 1 - 5 ⭐

        [Column("comment")]
        public string? Comment { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Product? Product { get; set; }
    }
}
