using System.ComponentModel.DataAnnotations;

namespace UmbracoEssential.Core.ViewModels
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Please Enter Your Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Your Email Address")]
        [EmailAddress(ErrorMessage = "You must enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Your Message")]
        [MaxLength(length: 500, ErrorMessage = "Your message must be no longer then 500 characters")]
        public string Message { get; set; }

        public int ContactFormId { get; set; }
    }
}
