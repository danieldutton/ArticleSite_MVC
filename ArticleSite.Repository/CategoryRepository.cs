using ArticleSite.DataAccess;
using ArticleSite.Model.Entities;
using ArticleSite.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArticleSite.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbContext _db;

        public List<Category> All { get { return _db.Categories.ToList(); } }


        public CategoryRepository(IDbContext dbContext)
        {
            _db = dbContext;
        }

        public Category Find(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Category entity)
        {
            if (All.Any(x => x.Name.Equals(entity.Name)))
            {
                _db.Categories.Add(entity);
                _db.SaveChanges();    
            }            
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
