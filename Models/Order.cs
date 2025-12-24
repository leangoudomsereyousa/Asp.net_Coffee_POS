using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_POS.Models
{
    [Table("orders")]
    public class Order
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("product_id")]
        public long ProductId { get; set; }

        [Column("user_id")]
        public long UserId { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("order_code")]
        public string OrderCode { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("totalprice")]
        public decimal TotalPrice { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [Column("payment_method")]
        public string PaymentMethod { get; set; }

        [Column("order_type")]
        public string OrderType { get; set; }

        [Column("size")]
        public string Size { get; set; }

        [Column("notes")]
        public string Notes { get; set; }

        [Column("delivery_location_id")]
        public long? DeliveryLocationId { get; set; }

        // Relationships
        public Product Product { get; set; }
        public User User { get; set; }
    }
}
