using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArticleSite.Model.Entities
{
    public class Article
    {
        public int ArticleId { get; set; }

        [Required]
        public DateTime DatePublished { get; set; }

        public DateTime? DateEdited { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Title is required")]
        [MaxLength(100, ErrorMessage = "Title max 70 characters")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Content is required")]
        [MaxLength(4000, ErrorMessage = "Content max 6000 characters")]
        public string Content { get; set; }

        public int CategoryId { get; set; }

        public List<Category> Categories { get; set; }
    }
}
