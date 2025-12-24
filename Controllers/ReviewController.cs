using Microsoft.AspNetCore.Mvc;
using Coffee_POS.Models;
using Microsoft.EntityFrameworkCore;

public class ReviewController : Controller
{
    [HttpGet]
    public IActionResult Review()
    {
        return View(new Review());
    }

    [HttpPost]
    public IActionResult AddReview(Review model)
    {
        if (!ModelState.IsValid)
        {
            return View("Review", model);
        }

        // TODO: Save to database here

        TempData["Success"] = "Thanks for your review!";
        return RedirectToAction("Index", "Home");
    }
}
