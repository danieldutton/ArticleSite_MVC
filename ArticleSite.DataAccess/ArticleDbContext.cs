using ArticleSite.Model.Entities;
using System.Data;
using System.Data.Entity;

namespace ArticleSite.DataAccess
{
    public class ArticleDbContext : DbContext, IDbContext
    {
        public IDbSet<Article> Articles { get; set; }

        public IDbSet<Category> Categories { get; set; }
        

        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

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
