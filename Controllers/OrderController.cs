using System;

using Coffee_POS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Coffee_POS.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;

        public OrderController(AppDbContext context)
        {
            _context = context;
        }

        // POS screen
        public async Task<IActionResult> Index()
        {
            ViewBag.Products = await _context.Products.ToListAsync();
            return View();
        }

        // Submit checkout (1 product = 1 order row)
        [HttpPost]
        public async Task<IActionResult> Checkout(
            long productId,
            int qty,
            decimal totalAmount,
            string paymentMethod,
            string orderType,
            string size,
            string? notes)
        {
            var order = new Order
            {
                ProductId = productId,
                UserId = 1, // Temp (session in real system)
                Quantity = qty,
                TotalPrice = totalAmount,
                PaymentMethod = paymentMethod,
                OrderType = orderType,
                Size = size,
                Notes = notes,
                Status = "1", // completed
                OrderCode = Guid.NewGuid().ToString().Substring(0, 8),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.Orders.Add(order);

            // deduct product stock
            var p = await _context.Products.FindAsync(productId);
            if (p != null)
                p.Qty -= qty;

            await _context.SaveChangesAsync();

            return RedirectToAction("Receipt", new { id = order.Id });
        }

        // Display receipt
        public async Task<IActionResult> Receipt(long id)
        {
            var order = await _context.Orders
                .Include(o => o.Product)
                .Include(o => o.User)
                .FirstOrDefaultAsync(o => o.Id == id);

            return View(order);
        }

        // Order History
        public async Task<IActionResult> List()
        {
            var data = await _context.Orders
                .Include(o => o.Product)
                .Include(o => o.User)
                .OrderByDescending(o => o.Id)
                .ToListAsync();

            return View(data);
        }
    }
}
