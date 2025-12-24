using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_POS.Models
{
    [Table("order_rejects")]   // 👉 Laravel table name
    public class OrderReject
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int UserId { get; set; }

        public string OrderCode { get; set; }

        public string Status { get; set; }

        // OPTIONAL relations:
        // public Product Product { get; set; }
        // public User User { get; set; }
    }
}
