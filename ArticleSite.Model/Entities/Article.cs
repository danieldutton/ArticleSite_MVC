using System;
using System.ComponentModel.DataAnnotations;

namespace ArticleSite.Model.Entities
{
    public class Article
    {
        public int Id { get; set; }

        [Required]
        public DateTime DatePublished { get; set; }

        public DateTime DateEdited { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title max 70 characters")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Content is required")]
        [StringLength(6000, ErrorMessage = "Title max 6000 characters")]
        public string Content { get; set; }
    }
}
