using ArticleSite.Model.Entities;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace ArticleSite.DataAccess.Interfaces
{
    public interface IDbContext
    {
        IDbSet<Article> Articles { get; set; }

        IDbSet<Category> Categories { get; set; }

        int SaveChanges();

        void SetModified(object entity);

        DbEntityEntry Entry(object o);

    }
}
