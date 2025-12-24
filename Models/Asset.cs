using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_POS.Models
{
    [Table("assets")]
    public class Asset
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("asset_category_id")]
        public long AssetCategoryId { get; set; }

        [Column("assigned_user_id")]
        public long? AssignedUserId { get; set; }

        [Column("purchase_date")]
        public DateTime PurchaseDate { get; set; }

        [Column("purchase_value")]
        public decimal PurchaseValue { get; set; }

        [Column("depreciation_rate")]
        public decimal DepreciationRate { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("unit")]
        public string Unit { get; set; }

        [Column("warranty_expiry_date")]
        public DateTime? WarrantyExpiryDate { get; set; }

        [Column("serial_number")]
        public string SerialNumber { get; set; }

        [Column("notes")]
        public string? Notes { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        // ---------------------------
        // Navigation Properties
        // ---------------------------

        [ForeignKey("AssetCategoryId")]
        public AssetCategory? Category { get; set; }

        [ForeignKey("AssignedUserId")]
        public User? AssignedUser { get; set; }
    }
}
