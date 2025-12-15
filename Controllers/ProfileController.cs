using System;
using System.Security.Cryptography;
using System.Text;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Coffee_POS.Controllers
{
    public class ProfileController : Controller
    {
        private readonly AppDbContext _context;

        public ProfileController(AppDbContext context)
        {
            _context = context;
        }

        // SHOW PROFILE
        public IActionResult Index()
        {
            string? uid = HttpContext.Session.GetString("UserId");

            if (uid == null)
                return RedirectToAction("Login", "Auth");

            long userId = long.Parse(uid);

            var user = _context.Users.FirstOrDefault(u => u.Id == userId);

            return View(user);
        }

        // UPDATE PROFILE
        [HttpPost]
        public IActionResult Update(long id, string name, string email, string? newPassword)
        {
            var user = _context.Users.Find(id);

            if (user == null)
                return NotFound();

            user.Name = name;
            user.Email = email;
            user.UpdatedAt = DateTime.Now;

            // If user wants to change password
            if (!string.IsNullOrEmpty(newPassword))
            {
                user.Password = HashPassword(newPassword);
            }

            _context.Users.Update(user);
            _context.SaveChanges();

            TempData["success"] = "Profile updated successfully!";
            return RedirectToAction("Index");
        }

        // SIMPLE PASSWORD HASH (SHA256)
        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }
    }
}
