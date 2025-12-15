
using Coffee_POS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Coffee_POS.Controllers
{
    public class AssetController : Controller
    {
        private readonly AppDbContext _context;
        public AssetController(AppDbContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            var data = await _context.Assets
                .Include(a => a.Category)
                .Include(a => a.AssignedUser)
                .OrderByDescending(a => a.Id)
                .ToListAsync();

            return View(data);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _context.Categories.ToListAsync();
            ViewBag.Users = await _context.Users.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Asset model)
        {
            model.CreatedAt = DateTime.Now;

            _context.Assets.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(long id)
        {
            var a = await _context.Assets.FindAsync(id);

            ViewBag.Categories = await _context.Categories.ToListAsync();
            ViewBag.Users = await _context.Users.ToListAsync();

            return View(a);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Asset model)
        {
            model.UpdatedAt = DateTime.Now;

            _context.Assets.Update(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(long id)
        {
            var a = await _context.Assets.FindAsync(id);

            _context.Assets.Remove(a);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
