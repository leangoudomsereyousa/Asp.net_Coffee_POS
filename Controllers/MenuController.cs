using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Coffee_POS.ViewModels;

namespace Coffee_POS.Controllers
{
    public class MenuController : Controller
    {
        private readonly AppDbContext _context;

        public MenuController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string? searchKey, long? categoryId)
        {
            var products = _context.Products
                .Include(p => p.Category)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchKey))
            {
                products = products.Where(p => p.Name.Contains(searchKey));
            }

            if (categoryId.HasValue)
            {
                products = products.Where(p => p.CategoryId == categoryId);
            }

            var vm = new MenuViewModel
            {
                Products = products.ToList(),
                Categories = _context.Categories.ToList(),
                SearchKey = searchKey,
                CartCount = 0,
                OrderCount = 0
            };

            return View(vm);
        }
    }
}
