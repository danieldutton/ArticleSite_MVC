using ArticleSite.DataAccess.Interfaces;
using ArticleSite.Model.Entities;
using ArticleSite.Repository;
using Moq;
using NUnit.Framework;

namespace ArticleSite._UnitTests.Repository
{
    [TestFixture]
    public class CategoryRepository_Should
    {
        [Test]
        public void Add_CallCategoriesOnce()
        {
            var fakeDbContext = new Mock<IDbContext>();
            var sut = new CategoryRepository(fakeDbContext.Object);
            var category = new Category();
            sut.Add(category);

            fakeDbContext.Verify(x => x.Categories, Times.Exactly(2));
        }
    }
}
