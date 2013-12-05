using ArticleSite.DataAccess;
using ArticleSite.Model.Entities;
using ArticleSite.Repository;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;

namespace ArticleSite._IntegrationTests.Repository_DbContext
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
            Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0", "",
                    string.Format("Data Source=\"{0}\";", DbFile));
            Database.SetInitializer(new DataInitialiser());

            _dataContext = new ArticleDbContext();
            _dataContext.Database.Initialize(true);
            _sut = new CategoryRepository(_dataContext);
        }

        [Test]
        public void All_ReturnAllCategories()
        {
            List<Category> result = _sut.All;

            Assert.AreEqual(11, result.Count);
        }

        [Test]
        public void Find_FindCorrectCategoryById()
        {
            Category result = _sut.Find(3);

            Assert.IsTrue(result.Id == 3);
        }

        [Test]
        public void Find_ReturnNullIfACategoryWithAMatchingIdDoesNotExist()
        {
            Category result = _sut.Find(13);

            Assert.IsTrue(result == null); 
        }

        [Test]
        public void Add_AddANewCategoryToTheDatabase()
        {
            var category = new Category {Name = "New Category"};

            _sut.Add(category);
            Category newCategory = _sut.Find(12);

            Assert.AreEqual(12, newCategory.Id);
            Assert.AreEqual("New Category", newCategory.Name);
        }

        [Test]
        public void Add_FailToInsertACategoryIfItAlreadyExistsByName()
        {
            var duplicateCategory = new Category {Name = "Category One"};

            _sut.Add(duplicateCategory);
            List<Category> categoryList = _sut.All.Where(x => x.Name.Contains("Category One")).ToList();

            Assert.AreEqual(1, categoryList.Count);           
        }

        [Test]
        public void Update_UpdateARecordInTheDatabase()
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
            var deletedResult = _sut.Find(3);

            Assert.IsTrue(deletedResult == null);
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
