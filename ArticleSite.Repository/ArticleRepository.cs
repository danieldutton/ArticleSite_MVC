using ArticleSite.DataAccess;
using ArticleSite.Model.Entities;
using ArticleSite.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArticleSite.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly IDbContext _db;

        public ArticleRepository(IDbContext dbContext)
        {
            _db = dbContext;
        }

        public List<Article> All { get { return _db.Articles.OrderByDescending(p => p.DatePublished).ToList(); } }
        
        public Article Find(int id)
        {
            return _db.Articles.Find(id);
        }

        public void Add(Article entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Article entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Article entity)
        {
            var post = All.SingleOrDefault(p => p.Id == entity.Id);
            _db.Articles.Remove(post);

            _db.SaveChanges();
        }

        public Article LatestArticle()
        {
            return All.OrderByDescending(x => x.DatePublished).FirstOrDefault();
        }

        public List<Article> LatestArticles(int count)
        {
            return All.OrderByDescending(x => x.DatePublished).Take(count).ToList();
        }
    }
}
