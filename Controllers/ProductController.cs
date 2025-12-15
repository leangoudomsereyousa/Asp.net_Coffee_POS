
using Coffee_POS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Coffee_POS.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // List all products
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .OrderByDescending(p => p.Id)
                .ToListAsync();

            return View(products);
        }

        // Create form
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _context.Categories.ToListAsync();
            return View();
        }

        // POST Create
        [HttpPost]
        public async Task<IActionResult> Create(Product model, IFormFile? ImageFile)
        {
            if (ImageFile != null)
            {
                string folder = Path.Combine(_env.WebRootPath, "images/products");
                Directory.CreateDirectory(folder);

                string filename = Guid.NewGuid() + Path.GetExtension(ImageFile.FileName);
                string filepath = Path.Combine(folder, filename);

                using (var stream = new FileStream(filepath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                model.Image = filename;
            }

            model.CreatedAt = DateTime.Now;

            _context.Products.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // Edit form
        public async Task<IActionResult> Edit(long id)
        {
            var product = await _context.Products.FindAsync(id);
            ViewBag.Categories = await _context.Categories.ToListAsync();
            return View(product);
        }

        // POST Edit
        [HttpPost]
        public async Task<IActionResult> Edit(Product model, IFormFile? ImageFile)
        {
            var dbProduct = await _context.Products.FindAsync(model.Id);

            if (dbProduct == null)
                return NotFound();

            dbProduct.Name = model.Name;
            dbProduct.Qty = model.Qty;
            dbProduct.CategoryId = model.CategoryId;
            dbProduct.Description = model.Description;
            dbProduct.UpdatedAt = DateTime.Now;

            // Image upload
            if (ImageFile != null)
            {
                string folder = Path.Combine(_env.WebRootPath, "images/products");
                Directory.CreateDirectory(folder);

                string filename = Guid.NewGuid() + Path.GetExtension(ImageFile.FileName);
                string filepath = Path.Combine(folder, filename);

                using (var stream = new FileStream(filepath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                dbProduct.Image = filename;
            }

            _context.Products.Update(dbProduct);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // Delete
        public async Task<IActionResult> Delete(long id)
        {
            var p = await _context.Products.FindAsync(id);

            if (p != null)
            {
                _context.Products.Remove(p);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}
