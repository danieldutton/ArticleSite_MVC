using ArticleSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace ArticleSite.DataAccess
{
    public class DataInitialiser : DropCreateDatabaseAlways<ArticleDbContext>
    {
        protected override void Seed(ArticleDbContext context)
        {
            var articles = new List<Article>
                {
                    new Article { DatePublished = new DateTime(2011, 12, 2), Title = "Title 1",  Content = "Content 1", Categories = new List<Category> {new Category {Name = "Category 1"}}},
                    new Article { DatePublished = new DateTime(2011, 12, 2), Title = "Title 2",  Content = "Content 2", Categories = new List<Category> {new Category {Name = "Category 2"}}},
                    new Article { DatePublished = new DateTime(2011, 12, 2), Title = "Title 3",  Content = "Content 3", Categories = new List<Category> {new Category {Name = "Category 3"}}},
                    new Article { DatePublished = new DateTime(2011, 12, 2), Title = "Title 4",  Content = "Content 4", Categories = new List<Category> {new Category {Name = "Category 4"}}},
                    new Article { DatePublished = new DateTime(2011, 12, 2), Title = "Title 5",  Content = "Content 5", Categories = new List<Category> {new Category {Name = "Category 5"}}},
                };

            foreach (var article in articles)
            {
                context.Articles.Add(article);
            }

            base.Seed(context);
        }
    }
}
