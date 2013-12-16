using System;
using System.ComponentModel.DataAnnotations;

namespace ArticleSite.Model.Entities
{
    public class NewsLetter
    {
        public int Id { get; set; }

        [Required]
        public DateTime DatePublished { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public bool Emailed { get; set; }
    }
}
