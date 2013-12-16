using System.ComponentModel.DataAnnotations;

namespace ArticleSite.Model.Entities
{
    public class Subscriber
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        public bool IsSubscribed { get; set; }


        public Subscriber()
        {
            IsSubscribed = true;
        }
    }
}
