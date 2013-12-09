using ArticleSite.Model.Entities;
using System.Collections.Generic;

namespace ArticleSite.Presentation.ViewModels
{
    public class ArticlesPartialViewModel
    {
        public string DatePublished { get; set; }

        public string DateEdited { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public List<Category> Categories { get; set; }
    }
}