using ArticleSite.DataAccess;
using ArticleSite.Model.Entities;
using ArticleSite.Presentation.Controllers;
using ArticleSite.Repository;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;

namespace ArticleSite._IntegrationTests.Controller_Repository_Data
{
    [TestFixture]
    public class HomeController_Should
    {
        private const string DbFile = "ArticleSite.DataAccess.ArticleDbContext";
        
        private ArticleDbContext _dataContext;

        private HomeController _sut;

        [SetUp]
        public void InitTest()
        {
            Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0", "",
                    string.Format("Data Source=\"{0}\";", DbFile));
            Database.SetInitializer(new DataInitialiser());

            _dataContext = new ArticleDbContext();
            _dataContext.Database.Initialize(true);
            _sut = new HomeController(new ArticleRepository(_dataContext));

        }

        [Test]
        public void ReturnTheCorrectModelType()
        {
            var result = _sut.Index().Model as List<Article>;

            Assert.IsInstanceOf(typeof(List<Article>), result);
        }

        [Test]
        public void Index_ReturnTheCorrectCountOfArticles()
        {
            var result = _sut.Index().Model as List<Article>;

            Assert.AreEqual(10, result.Count);
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
