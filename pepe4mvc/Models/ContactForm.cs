using System.ComponentModel.DataAnnotations;

namespace pepe4mvc.Models
{
    public class ContactForm
    {
        [Key]
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; }= string.Empty;
        public string Message { get; set; }= string.Empty;
    }
}
