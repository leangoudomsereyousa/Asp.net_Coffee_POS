using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Coffee_POS.Controllers
{
    public class ReportController : Controller
    {
        private readonly AppDbContext _context;

        public ReportController(AppDbContext context)
        {
            _context = context;
        }

        // TODAY REPORT
        public async Task<IActionResult> Today()
        {
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);

            var orders = await _context.Orders
                .Include(o => o.Product)
                .Where(o => o.CreatedAt >= today && o.CreatedAt < tomorrow)
                .OrderByDescending(o => o.Id)
                .ToListAsync();

            return View(orders);
        }

        // MONTHLY REPORT
        public async Task<IActionResult> Monthly()
        {
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;

            var data = await _context.Orders
                .Include(o => o.Product)
                .Where(o => o.CreatedAt.Value.Month == month &&
                            o.CreatedAt.Value.Year == year)
                .OrderByDescending(o => o.Id)
                .ToListAsync();

            return View(data);
        }

        // PRODUCT SALES REPORT
        public async Task<IActionResult> ProductSales()
        {
            var data = await _context.Orders
                .Include(o => o.Product)
                .GroupBy(o => o.Product.Name)
                .Select(g => new ProductSalesVM
                {
                    ProductName = g.Key,
                    Quantity = g.Sum(x => x.Quantity),
                    Total = g.Sum(x => x.TotalPrice)
                })
                .ToListAsync();

            return View(data);
        }
    }

    // VIEW MODEL FOR ProductSales
    public class ProductSalesVM
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
