using ArticleSite.DataAccess;
using ArticleSite.Model.Entities;
using ArticleSite.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ArticleSite.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ArticleDbContext _db;

        public List<Category> All
        {
            get { return _db.Categories.ToList(); }
        }

        public CategoryRepository(ArticleDbContext dbContext)
        {
            _db = dbContext;
        }

        public Category Find(int id)
        {
            return _db.Categories.Find(id);
        }

        public void Add(Category entity)
        {
            Category category = _db.Categories
                .FirstOrDefault(c => c.Name
                    .Equals(entity.Name, StringComparison.InvariantCultureIgnoreCase));

            if (category != null) return;

            _db.Categories.Add(entity);
            _db.SaveChanges();
        }

        public void Update(Category entity)
        {
            Category category = _db.Categories
                .FirstOrDefault(c => c.Name
                    .Equals(entity.Name, StringComparison.InvariantCultureIgnoreCase));

            if (category != null) return;

            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(Category entity)
        {
            Category category = All.
                SingleOrDefault(c => c.CategoryId == entity.CategoryId);

            if (category != null)
            {
                _db.Categories.Remove(category);
                _db.SaveChanges();
            }
        }

        public List<Category> CategoriesByNameAscending(int count)
        {
            int categoryNos = All.Count();

            if (count > categoryNos) count = 5;

            List<Category> categories = All
                .OrderBy(c => c.Name)
                .Take(count)
                .ToList();

            return categories;
        }
    }
}