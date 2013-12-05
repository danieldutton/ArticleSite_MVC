using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ArticleSite.DataAccess;
using ArticleSite.Model.Entities;
using ArticleSite.Presentation.Controllers;
using ArticleSite.Repository;
using NUnit.Framework;

namespace ArticleSite._IntegrationTests.Controller_Repository
{
    [TestFixture]
    public class HomeController_Should
    {

        protected const string DbFile = "ArticleSite.DataAccess.ArticleDbContext";
        protected const string Password = "1234567890";
        protected ArticleDbContext DataContext;

        [SetUp]
        public void InitTest()
        {
            Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0", "",
                    string.Format("Data Source=\"{0}\";", DbFile));
            Database.SetInitializer(new DataInitialiser());

            DataContext = new ArticleDbContext();
            DataContext.Database.Initialize(true);
        }

        [Test]
        public void Foo()
        {
            var rep = new ArticleRepository(DataContext);
            var hc = new HomeController(rep);

            var result = hc.Index().Model as List<Article>;

            Assert.AreEqual(5, result.Count);
        }
    }
}
