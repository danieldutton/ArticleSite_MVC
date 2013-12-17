using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArticleSite.Model.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Category name is required")]
        [MaxLength(70, ErrorMessage = "Category max 70 characters")]
        public string Name { get; set; }

        public List<Article> Articles { get; set; }
    }
}
