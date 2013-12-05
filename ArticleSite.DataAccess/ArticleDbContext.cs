using ArticleSite.Model.Entities;
using System.Data.Entity;

namespace ArticleSite.DataAccess
{
    public class ArticleDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>()
                         .HasMany(j => j.Categories)
                         .WithMany(j => j.Articles)
                         .Map(x => x.ToTable("ArticleCategory"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
