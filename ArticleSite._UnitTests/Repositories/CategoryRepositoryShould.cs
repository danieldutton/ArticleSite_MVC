using ArticleSite.DataAccess;
using ArticleSite.Model.Entities;
using ArticleSite.Repository;
using Moq;
using NUnit.Framework;
using System.Data.Entity;

namespace ArticleSite._UnitTests.Repositories
{
    [TestFixture]
    public class CategoryRepositoryShould
    {
        [Test]
        public void Find_CallCategoriesExactlyOnce()
        {
            var mockSet = new Mock<DbSet<Category>>();
            var mockContext = new Mock<ArticleDbContext>();
            mockContext.Setup(x => x.Categories).Returns(mockSet.Object);

            var sut = new CategoryRepository(mockContext.Object);
            sut.Find(1);

            mockContext.Verify(x => x.Categories, Times.Once());
        }

        [Test]
        public void Add_CallCategoriesExactlyOnce()
        {
            var mockSet = new Mock<DbSet<Category>>();
            mockSet.Setup(x => x.Add(It.IsAny<Category>())).Returns(() => new Category());
            var mockContext = new Mock<ArticleDbContext>();
            mockContext.Setup(x => x.Categories).Returns(mockSet.Object);

            var sut = new CategoryRepository(mockContext.Object);
            sut.Add(new Category());

            mockContext.Verify(x => x.Categories, Times.Exactly(2));
        }

        [Test]
        public void Add_AddNothingAndReturnIfCategoryIsNull()
        {
            var mockSet = new Mock<DbSet<Category>>();
            mockSet.Setup(x => x.Add(It.IsAny<Category>())).Returns(() => new Category());
            var mockContext = new Mock<ArticleDbContext>();
            mockContext.Setup(x => x.Categories).Returns(mockSet.Object);

            var sut = new CategoryRepository(mockContext.Object);
            sut.Add(new Category());

            mockContext.Verify(x => x.Categories.Find(1), Times.Exactly(2));
        }

        //[Test]
        //public void Add_CallCategoriesExactlyOnce()
        //{
        //    var mockSet = new Mock<DbSet<Category>>();
        //    var mockContext = new Mock<ArticleDbContext>();
        //    mockContext.Setup(x => x.Categories).Returns(mockSet.Object);

        //    var sut = new CategoryRepository(mockContext.Object);
        //    sut.Find(1);

        //    mockContext.Verify(x => x.Categories.Find(1), Times.Exactly(2));
        //}

        [Test]
        public void Add_CallSaveChangesExactlyOnce()
        {
            var mockSet = new Mock<DbSet<Category>>();
            var mockContext = new Mock<ArticleDbContext>();
            mockContext.Setup(x => x.Categories).Returns(mockSet.Object);

            var sut = new CategoryRepository(mockContext.Object);
            sut.Add(new Category());

            mockContext.Verify(x => x.SaveChanges(), Times.Exactly(2));
        }

        [Test]
        public void Update_CallAllExactlyOnce()
        {
            var mockSet = new Mock<DbSet<Category>>();
            var mockContext = new Mock<ArticleDbContext>();
            mockContext.Setup(x => x.Categories).Returns(mockSet.Object);

            var sut = new CategoryRepository(mockContext.Object);
            sut.Find(1);

            mockContext.Verify(x => x.Categories.Find(1), Times.Exactly(2));
        }

        [Test]
        public void Update_UpdateNothingAndReturnIfCategoryIsNull()
        {
            var mockSet = new Mock<DbSet<Category>>();
            var mockContext = new Mock<ArticleDbContext>();
            mockContext.Setup(x => x.Categories).Returns(mockSet.Object);

            var sut = new CategoryRepository(mockContext.Object);
            sut.Find(1);

            mockContext.Verify(x => x.Categories.Find(1), Times.Exactly(2));
        }

        [Test]
        public void Update_CallSetModifiedExactlyOnce()
        {
            var mockSet = new Mock<DbSet<Category>>();
            var mockContext = new Mock<ArticleDbContext>();
            mockContext.Setup(x => x.Categories).Returns(mockSet.Object);

            var sut = new CategoryRepository(mockContext.Object);
            sut.Find(1);

            mockContext.Verify(x => x.Categories.Find(1), Times.Exactly(2));
        }

        [Test]
        public void Update_CallSaveChangesExactlyOnce()
        {
            var mockSet = new Mock<DbSet<Category>>();
            var mockContext = new Mock<ArticleDbContext>();
            mockContext.Setup(x => x.Categories).Returns(mockSet.Object);

            var sut = new CategoryRepository(mockContext.Object);
            sut.Find(1);

            mockContext.Verify(x => x.Categories.Find(1), Times.Exactly(2));
        }

        [Test]
        public void Delete_CallAllExactlyOnce()
        {
            var mockSet = new Mock<DbSet<Category>>();
            var mockContext = new Mock<ArticleDbContext>();
            mockContext.Setup(x => x.Categories).Returns(mockSet.Object);

            var sut = new CategoryRepository(mockContext.Object);
            sut.Find(1);

            mockContext.Verify(x => x.Categories.Find(1), Times.Exactly(2));
        }

        [Test]
        public void Delete_UpdateNothingAndReturnIfCategoryIsNull()
        {
            var mockSet = new Mock<DbSet<Category>>();
            var mockContext = new Mock<ArticleDbContext>();
            mockContext.Setup(x => x.Categories).Returns(mockSet.Object);

            var sut = new CategoryRepository(mockContext.Object);
            sut.Find(1);

            mockContext.Verify(x => x.Categories.Find(1), Times.Exactly(2));
        }

        [Test]
        public void Delete_CallCategoriesExactlyOnce()
        {
            var mockSet = new Mock<DbSet<Category>>();
            var mockContext = new Mock<ArticleDbContext>();
            mockContext.Setup(x => x.Categories).Returns(mockSet.Object);

            var sut = new CategoryRepository(mockContext.Object);
            sut.Find(1);

            mockContext.Verify(x => x.Categories.Find(1), Times.Exactly(2));
        }

        [Test]
        public void Delete_CallSaveChangesExactlyOnce()
        {
            var mockSet = new Mock<DbSet<Category>>();
            var mockContext = new Mock<ArticleDbContext>();
            mockContext.Setup(x => x.Categories).Returns(mockSet.Object);

            var sut = new CategoryRepository(mockContext.Object);
            sut.Find(1);

            mockContext.Verify(x => x.Categories.Find(1), Times.Exactly(2));
        }

        [Test]
        public void CategoriesByNameAscending_CallAllCountExactlyOnce()
        {
            
        }

        [Test]
        public void CategoriesByNameAscending_SetCountTo5IfCountParamIsGretaerThanCategories()
        {
            
        }

        [Test]
        public void CategoriesByNameAscending_CallAllExactlyOnce()
        {
            
        }
    }
}
