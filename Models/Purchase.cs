using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_POS.Models
{
    [Table("purchases")]
    public class Purchase
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("supplier_id")]
        public long SupplierId { get; set; }

        [Column("total_amount")]
        public decimal TotalAmount { get; set; }

        [Column("paid_amount")]
        public decimal PaidAmount { get; set; }

        [Column("due_amount")]
        public decimal DueAmount { get; set; }

        [Column("payment_status")]
        public string PaymentStatus { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        // Navigation Properties
        public Supplier? Supplier { get; set; }
        public List<PurchaseItem>? Items { get; set; }
    }
}
