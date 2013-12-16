using System.ComponentModel.DataAnnotations;

namespace ArticleSite.Model.Entities
{
    public class Subscriber
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        public bool CurrentlySubscribed { get; set; }


        public Subscriber()
        {
            CurrentlySubscribed = true;
        }
    }
}
