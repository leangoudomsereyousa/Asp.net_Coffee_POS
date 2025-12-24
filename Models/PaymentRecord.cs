using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_POS.Models
{
    [Table("payment_records")]   
    public class PaymentRecord
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Status { get; set; }

        public string OrderCode { get; set; }

        public decimal NetAmount { get; set; }

        public decimal PaidAmount { get; set; }

        public decimal ChangeAmount { get; set; }

        public string PaymentMethod { get; set; }

        // OPTIONAL: If User Model exists and you want navigation
        // public User User { get; set; }
    }
}
