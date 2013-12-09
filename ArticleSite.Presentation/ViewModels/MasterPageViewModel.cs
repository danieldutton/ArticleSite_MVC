using ArticleSite.Model.Entities;
using System.Collections.Generic;

namespace ArticleSite.Presentation.ViewModels
{
    public class MasterPageViewModel
    {
        public Article Article { get; set; }

        public string ArticleSummary { get; set; }

        public List<Category> Categories { get; set; }
    }
}