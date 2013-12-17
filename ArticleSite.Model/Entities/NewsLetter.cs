using System;
using System.ComponentModel.DataAnnotations;

namespace ArticleSite.Model.Entities
{
    public class NewsLetter
    {
        public int Id { get; set; }

        [Required]
        public DateTime DatePublished { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "A Subject is required")]
        public string Subject { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Content is required")]
        public string Content { get; set; }

        [Required]
        public bool Emailed { get; set; }
    }
}
