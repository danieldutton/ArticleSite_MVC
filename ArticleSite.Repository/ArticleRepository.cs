using ArticleSite.DataAccess.Interfaces;
using ArticleSite.Model.Entities;
using ArticleSite.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ArticleSite.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly IDbContext _db;

        public List<Article> All { get { return _db.Articles.ToList(); } }


        public ArticleRepository(IDbContext dbContext)
        {
            _db = dbContext;
        }
        
        public Article Find(int id)
        {
            return _db.Articles.Find(id);
        }

        public void Add(Article entity)
        {    

            _db.Articles.Add(entity);
            _db.SaveChanges();
        }

        public void Update(Article entity)
        {
            _db.SetModified(entity);
            _db.SaveChanges();
        }

        public void Delete(Article entity)
        {
            var post = All.SingleOrDefault(a => a.ArticleId == entity.ArticleId);
            
            if (post != null)
            {
                _db.Articles.Remove(post);

                _db.SaveChanges();    
            }            
        }

        public Article LatestArticle()
        {
            return All.OrderByDescending(a => a.DatePublished).FirstOrDefault();
        }

        public List<Article> LatestArticles(int count)
        {
            return All.OrderByDescending(a => a.DatePublished).Take(count).ToList();
        }

        public List<Article> ArticlesByCategory(string category)
        {
            List<Article> articlesByCategory = _db.Articles.Where(a => a.Categories.Any(c => c.Name.Contains(category))).ToList();

            return articlesByCategory;
        }

        public IEnumerable<IGrouping<int, Article>> ArticlesGroupedByYear()
        {
            IEnumerable<IGrouping<int, Article>> groupedPosts = _db.Articles
                                              .AsEnumerable()
                                              .OrderByDescending(a => a.DatePublished)
                                              .GroupBy(a => a.DatePublished.Year)
                                              .OrderByDescending(p => p.Key)
                                              .ToList();
            return groupedPosts;
        }
    }
}
