using System.ComponentModel.DataAnnotations;

namespace ArticleSite.Model.Entities
{
    public class Subscriber
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        [MaxLength(254, ErrorMessage = "Max of 254 characters")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid e-mail format")]
        public string Email { get; set; }

        public bool IsSubscribed { get; set; }

        public Subscriber()
        {
            IsSubscribed = true;
        }
    }
}
