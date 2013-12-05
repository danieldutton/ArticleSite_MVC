using ArticleSite.Model.Entities;
using System.Data.Entity;

namespace ArticleSite.DataAccess
{
    public interface IDbContext
    {
        IDbSet<Article> Articles { get; set; }

        IDbSet<Category> Categories { get; set; }

        int SaveChanges();

        void SetModified(object entity);
    }
}
