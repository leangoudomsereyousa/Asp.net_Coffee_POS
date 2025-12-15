
using Coffee_POS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Coffee_POS.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            var data = await _context.Categories.ToListAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category model)
        {
            model.CreatedAt = DateTime.Now;
            _context.Categories.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(long id)
        {
            var data = await _context.Categories.FindAsync(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category model)
        {
            model.UpdatedAt = DateTime.Now;
            _context.Categories.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(long id)
        {
            var data = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(data);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
