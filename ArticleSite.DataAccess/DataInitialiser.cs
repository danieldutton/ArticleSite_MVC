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
                    new Article { DatePublished = new DateTime(2011, 12, 2), Title = "Title 1",  Content = "Content 1", Categories = new List<Category> {new Category {Name = "Category 1"}}},
                    new Article { DatePublished = new DateTime(2011, 12, 2), Title = "Title 1",  Content = "Content 1", Categories = new List<Category> {new Category {Name = "Category 1"}}},
                    new Article { DatePublished = new DateTime(2011, 12, 2), Title = "Title 1",  Content = "Content 1", Categories = new List<Category> {new Category {Name = "Category 1"}}},
                    new Article { DatePublished = new DateTime(2011, 12, 2), Title = "Title 1",  Content = "Content 1", Categories = new List<Category> {new Category {Name = "Category 1"}}},
                };

            foreach (var article in articles)
            {
                context.Articles.Add(article);
            }

            base.Seed(context);
        }
    }
}
