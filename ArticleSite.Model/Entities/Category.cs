using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArticleSite.Model.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Category name is required")]
        [StringLength(70, ErrorMessage = "Category max 70 characters")]
        public string Name { get; set; }

        public List<Article> Articles { get; set; }
    }
}
