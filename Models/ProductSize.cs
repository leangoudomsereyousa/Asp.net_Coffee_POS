using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_POS.Models
{
    [Table("product_sizes")]
    public class ProductSize
    {
        [Key]
        public long Id { get; set; }

        [Column("product_id")]
        [ForeignKey("Product")]  
        public long ProductId { get; set; }

        public Product Product { get; set; }

        [Column("size")]
        public string Size { get; set; } = "M";

        [Column("price")]
        public decimal Price { get; set; }
    }
}
