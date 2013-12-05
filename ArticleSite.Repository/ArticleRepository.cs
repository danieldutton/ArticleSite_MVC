﻿using ArticleSite.DataAccess;
using ArticleSite.Model.Entities;
using ArticleSite.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ArticleSite.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ArticleDbContext _db = new ArticleDbContext();

        public List<Article> All { get { return _db.Articles.OrderByDescending(p => p.DatePublished).ToList(); } }
        
        public Article Find(int id)
        {
            return _db.Articles.Find(id);
        }

        public void Add(Article entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Article entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Article entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
