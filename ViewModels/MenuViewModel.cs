using System.Collections.Generic;
using Coffee_POS.Models;

namespace Coffee_POS.ViewModels
{
    public class MenuViewModel
    {
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();

        public int CartCount { get; set; }
        public int OrderCount { get; set; }
        public string SearchKey { get; set; }
        //public int OrderCode { get; set; }

        // Pagination
        //public int PageNumber { get; set; } = 1;
        //public int PageSize { get; set; } = 12;
    }
}
