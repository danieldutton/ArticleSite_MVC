using System.ComponentModel.DataAnnotations;

namespace ArticleSite.Services
{
    public class Contact
    {
        [Required(ErrorMessage = "Name is required", AllowEmptyStrings = false)]
        [Display(Description = "Your Name")]
        [StringLength(70, ErrorMessage = "Max of 70 characters allowed")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Subject is required", AllowEmptyStrings = false)]
        [StringLength(70, ErrorMessage = "Max of 70 characters allowed")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Email is required", AllowEmptyStrings = false)]
        [StringLength(70, ErrorMessage = "Max of 70 characters allowed")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Message is required", AllowEmptyStrings = false)]
        [DataType(DataType.MultilineText)]
        [StringLength(500, ErrorMessage = "Max of 500 characters allowed")]
        public string Message { get; set; }
    }
}
