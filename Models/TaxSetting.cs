using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_POS.Models
{
    [Table("tax_settings")] 
    public class TaxSetting
    {
        [Key]
        public int Id { get; set; }

        public string? Tax_Name { get; set; }

        public decimal Tax_Rate { get; set; }
    }
}
