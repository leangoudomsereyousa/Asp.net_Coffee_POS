
using Coffee_POS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Coffee_POS.Controllers
{
    public class PurchaseItemController : Controller
    {
        private readonly AppDbContext _context;
        public PurchaseItemController(AppDbContext context) => _context = context;

        public async Task<IActionResult> Index(long purchaseId)
        {
            var data = await _context.PurchaseItems
                .Where(i => i.PurchaseId == purchaseId)
                .ToListAsync();

            ViewBag.PurchaseId = purchaseId;

            return View(data);
        }

        public IActionResult Create(long purchaseId)
        {
            ViewBag.PurchaseId = purchaseId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PurchaseItem model)
        {
            model.CreatedAt = DateTime.Now;
            model.TotalPrice = model.CostPrice * model.Quantity;

            _context.PurchaseItems.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { purchaseId = model.PurchaseId });
        }

        public async Task<IActionResult> Delete(long id)
        {
            var item = await _context.PurchaseItems.FindAsync(id);
            long purchaseId = item.PurchaseId;

            _context.PurchaseItems.Remove(item);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { purchaseId });
        }
    }
}
