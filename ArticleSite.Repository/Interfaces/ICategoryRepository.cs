using ArticleSite.Model.Entities;
using System.Collections.Generic;

namespace ArticleSite.Repository.Interfaces
{
    public interface ICategoryRepository : IEntityRepository<Category>
    {
        List<Category> CategoriesByNameAscending(int count);
    }
}
