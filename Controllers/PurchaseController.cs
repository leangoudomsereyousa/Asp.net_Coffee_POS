
using Coffee_POS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Coffee_POS.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly AppDbContext _context;
        public PurchaseController(AppDbContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            var data = await _context.Purchases
                .Include(p => p.Items)
                .ToListAsync();

            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Purchase model)
        {
            model.CreatedAt = DateTime.Now;

            // Calculate due
            model.DueAmount = model.TotalAmount - model.PaidAmount;

            _context.Purchases.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(long id)
        {
            var p = await _context.Purchases.FindAsync(id);
            return View(p);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Purchase model)
        {
            model.UpdatedAt = DateTime.Now;
            model.DueAmount = model.TotalAmount - model.PaidAmount;

            _context.Purchases.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(long id)
        {
            var p = await _context.Purchases.FindAsync(id);
            _context.Purchases.Remove(p);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
