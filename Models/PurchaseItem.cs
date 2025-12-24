using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_POS.Models
{
    [Table("purchase__items")]
    public class PurchaseItem
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("purchase_id")]
        public long PurchaseId { get; set; }

        [Column("ingredient_id")]
        public long IngredientId { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("cost_price")]
        public decimal CostPrice { get; set; }

        [Column("total_price")]
        public decimal TotalPrice { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        // Navigation
        public Purchase? Purchase { get; set; }
        public Ingredient? Ingredient { get; set; }
    }
}
