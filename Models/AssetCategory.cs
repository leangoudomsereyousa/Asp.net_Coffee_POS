using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_POS.Models
{
    [Table("asset_categories")]
    public class AssetCategory
    {
        //[Key]
        //[Column("id")]
        //public long Id { get; set; }

        //[Column("name")]
        //public string Name { get; set; }

        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        public ICollection<Asset> Assets { get; set; }
    }
}
