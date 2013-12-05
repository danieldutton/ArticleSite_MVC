using ArticleSite.DataAccess;
using ArticleSite.Model.Entities;
using ArticleSite.Repository.Interfaces;
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
            return _db.Categories.Find(id);
        }

        public void Add(Category entity)
        {
            if (All.Any(x => x.Name.Equals(entity.Name))) return;

            _db.Categories.Add(entity);
            _db.SaveChanges();
        }

        public void Update(Category entity)
        {
            _db.SetModified(entity);
            _db.SaveChanges();
        }

        public void Delete(Category entity)
        {
            var category = All.SingleOrDefault(c => c.Id == entity.Id);
            
            if (category != null)
            {
                _db.Categories.Remove(category);

                _db.SaveChanges();    
            }           
        }
    }
}
