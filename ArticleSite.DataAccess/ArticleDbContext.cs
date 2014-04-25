using ArticleSite.Model.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ArticleSite.DataAccess
{
    public class ArticleDbContext : DbContext
    {
        public virtual IDbSet<Article> Articles { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<Subscriber> Subscribers { get; set; }

        public virtual IDbSet<NewsLetter> NewsLetters { get; set; }


        public ArticleDbContext() : base("ArticleDb")
        {           
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Article>()
                         .HasMany(j => j.Categories)
                         .WithMany(j => j.Articles)
                         .Map(x => x.ToTable("ArticleCategory"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
