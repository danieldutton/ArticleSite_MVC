using ArticleSite.Model.Entities;
using System.Collections.Generic;

namespace ArticleSite.Repository.Interfaces
{
    public interface IArticleRepository : IEntityRepository<Article>
    {
        Article LatestArticle();

        List<Article> LatestArticles(int count);

        List<Article> ArticlesByCategory(string category);
    }
}
