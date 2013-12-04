using ArticleSite.Model.Entities;
using System.Data.Entity;

namespace ArticleSite.DataAccess
{
    public class ArticleDbContent : DbContext
    {
        DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
