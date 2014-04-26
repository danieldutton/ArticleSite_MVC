using ArticleSite.DataAccess;
using ArticleSite.Model.Entities;
using ArticleSite.Repository;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;

namespace ArticleSite.IntegrationTests.Repository_Data
{
    [TestFixture]
    public class CategoryRepository_Should
    {
        private const string DbFile = "ArticleSite.DataAccess.ArticleDbContext";

        private ArticleDbContext _dataContext;

        private CategoryRepository _sut;

        [SetUp]
        public void InitTest()
        {
            Database.SetInitializer(new ArticleDataInitialiser());

            _dataContext = new ArticleDbContext();
            _dataContext.Database.Initialize(true);
            _sut = new CategoryRepository(_dataContext);
        }

        [Test]
        public void All_ReturnEveryCategoryStored()
        {
            List<Category> result = _sut.All;

            Assert.AreEqual(10, result.Count);
        }

        [Test]
        public void Find_FindCorrectCategoryById_ThatExists()
        {
            Category result = _sut.Find(3);

            Assert.IsTrue(result.CategoryId == 3);
        }

        [Test]
        public void Find_ReturnNull_IfCategoryIdDoesNotExist()
        {
            Category result = _sut.Find(13);

            Assert.IsNull(result);
        }

        [Test]
        public void Add_AddANewCategoryToTheDatabase()
        {
            var category = new Category {Name = "New Category"};

            _sut.Add(category);
            Category newCategory = _sut.Find(11);

            Assert.AreEqual(11, newCategory.CategoryId);
            Assert.AreEqual("New Category", newCategory.Name);
        }

        [Test]
        public void Add_FailToInsertACategory_IfTheCategoryAlreadyExists()
        {
            var duplicateCategory = new Category {Name = "Category Two"};

            _sut.Add(duplicateCategory);
            List<Category> categoryList = _sut.All.
                Where(x => x.Name
                    .Contains("Category Two"))
                    .ToList();

            Assert.AreEqual(1, categoryList.Count);
        }

        [Test]
        public void Add_FailToInsertACategory_IfTheCategoryAlreadyExists_IgnoreCase()
        {
            var duplicateCategory = new Category {Name = "category one"};

            _sut.Add(duplicateCategory);
            List<Category> categoryList = _sut.All
                                              .Where(x => x.Name
                                              .Contains("category one"))
                                              .ToList();

            Assert.AreEqual(0, categoryList.Count);
        }

        [Test]
        public void Update_UpdateARecordInTheDatabase_IfItExists()
        {
            Category result = _sut.Find(3);
            result.Name = "Updated Category";
            
            _sut.Update(result);

            Category updatedCategory = _sut.Find(3);

            Assert.AreEqual("Updated Category", updatedCategory.Name);
        }

        [Test]
        public void Delete_DeleteARecordInTheDatabase()
        {
            Category result = _sut.Find(3);
            
            _sut.Delete(result);
            Category deletedResult = _sut.Find(3);

            Assert.IsTrue(deletedResult == null);
        }

        [Test]
        public void CategoriesByNameAscending_ReturnTheCorrectCountOfRequestedCategories()
        {
            List<Category> categories = _sut.CategoriesByNameAscending(5);

            Assert.AreEqual(5, categories.Count);
        }

        [Test]
        public void CategoriesByNameAscending_IfCountParamIsGreaterThanCategoriesReturnADefaultOfFiveItems()
        {
            List<Category> categories = _sut.CategoriesByNameAscending(55);

            Assert.AreEqual(5, categories.Count);
        }

        [Test]
        public void CategoriesByNameAscending_ReturnTheCorrectSequenceOrderedByNameAscending()
        {
            IEnumerable<string> categoryNames = _sut.CategoriesByNameAscending(5)
                                                    .Select(c => c.Name);

            IEnumerable<string> expected = new List<string>
                {
                    "Category Eight",
                    "Category Five",
                    "Category Four",
                    "Category Nine",
                    "Category One"
                };

            Assert.IsTrue(expected.SequenceEqual(categoryNames));
        }

        [TearDown]
        public void TearDown()
        {
            _dataContext.Dispose();

            if (File.Exists(DbFile))
            {
                File.Delete(DbFile);
            }
            _sut = null;
        }
    }
}