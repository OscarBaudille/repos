using Microsoft.AspNetCore.Mvc;
using pepe4mvc.Models;
using MailKit.Net.Smtp;
using MimeKit;

public class ContactController : Controller
{
    public IActionResult Index()
    {
        return View();
    }


    private readonly ApplicationDbContext _dbContext;

    public ContactController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public IActionResult Submit(ContactForm form)
    {
        if (ModelState.IsValid)
        {
            _dbContext.ContactForms.Add(form);
            _dbContext.SaveChanges();
            ViewData["Success"] = "Message saved!";

            SendEmail(form); // Agregar esta línea para enviar el correo
        }
        return View("Index", form);
    }



private void SendEmail(ContactForm form)
{
    var email = new MimeMessage();
    email.From.Add(new MailboxAddress("Your Site", "oscar.dypsa@gmail.com"));
    email.To.Add(new MailboxAddress("", form.Email));
    email.Subject = "Contact Form Submission";
    email.Body = new TextPart("plain") { Text = $"Name: {form.Name}\nMessage: {form.Message}" };

    using var smtp = new SmtpClient();
    smtp.Connect("smtp.gmail.com", 587, false);
    smtp.Authenticate("oscar.dypsa@gmail.com", "Zingara21");
    smtp.Send(email);
    smtp.Disconnect(true);
}


}