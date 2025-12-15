using System;
using System.Linq;
using System.Threading.Tasks; // <-- Add this

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Coffee_POS.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Count totals
            ViewBag.TotalProducts = await _context.Products.CountAsync();
            ViewBag.TotalOrders = await _context.Orders.CountAsync();
            ViewBag.TotalAssets = await _context.Assets.CountAsync();
            ViewBag.TotalPurchase = await _context.Purchases.CountAsync();

            // Get 5 recent orders with user info
            ViewBag.RecentOrders = await _context.Orders
                .Include(o => o.User)
                .OrderByDescending(o => o.Id)
                .Take(5)
                .ToListAsync();

            return View();
        }
    }
}
