using Microsoft.AspNetCore.Mvc;
using pepe4mvc.Models;

public class ContactController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Submit(ContactForm form)
    {
        if (ModelState.IsValid)
        {
            // Process form (e.g., save to database or send email)
            ViewData["Success"] = "Message sent successfully!";
        }
        return View("Index", form);
    }
}
