using ArticleSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace ArticleSite.DataAccess
{
    public class ArticleDataInitialiser : DropCreateDatabaseAlways<ArticleDbContext>
    {
        protected override void Seed(ArticleDbContext context)
        {
            var articles = new List<Article>
                {
                    new Article { DatePublished = new DateTime(2011, 8, 2), Title = "Title 1",  Content = "Content 1", Categories = new List<Category> {new Category {Name = "Category Onez"}}},
                    new Article { DatePublished = new DateTime(2012, 7, 5), Title = "Title 2",  Content = "Content 2", Categories = new List<Category> {new Category {Name = "Category Two"}}},
                    new Article { DatePublished = new DateTime(2013, 6, 7), Title = "Title 3",  Content = "Content 3", Categories = new List<Category> {new Category {Name = "Category Three"}}},
                    new Article { DatePublished = new DateTime(2013, 2, 22), Title = "Title 4",  Content = "Content 4", Categories = new List<Category> {new Category {Name = "Category Four"}}},
                    new Article { DatePublished = new DateTime(2013, 9, 14), Title = "Title 5",  Content = "Content 5", Categories = new List<Category> {new Category {Name = "Category Five"}}},
                    new Article { DatePublished = new DateTime(2012, 8, 2), Title = "Title 6",  Content = "Content 6", Categories = new List<Category> {new Category {Name = "Category Six"}}},
                    new Article { DatePublished = new DateTime(2012, 7, 5), Title = "Title 7",  Content = "Content 7", Categories = new List<Category> {new Category {Name = "Category Seven"}}},
                    new Article { DatePublished = new DateTime(2011, 5, 12), Title = "Title 8",  Content = "Content 8", Categories = new List<Category> {new Category {Name = "Category Eight"}}},
                    new Article { DatePublished = new DateTime(2013, 2, 24), Title = "Title 9",  Content = "Content 9", Categories = new List<Category> {new Category {Name = "Category Nine"}}},
                    new Article { DatePublished = new DateTime(2013, 9, 18), Title = "Title 10",  Content = "Content 10", Categories = new List<Category> {new Category {Name = "Category Ten"}}},
                };

            foreach (var article in articles)
            {
                context.Articles.Add(article);
            }

            base.Seed(context);
        }
    }
}
