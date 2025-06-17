using Microsoft.EntityFrameworkCore;
using pepe4mvc.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<ContactForm> ContactForms { get; set; }
}
