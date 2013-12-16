using ArticleSite.DataAccess;
using ArticleSite.Model.Entities;
using ArticleSite.Presentation.Controllers;
using ArticleSite.Repository;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Web.Mvc;

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
            Database.SetInitializer(new ArticleDataInitialiser());

            _dataContext = new ArticleDbContext();
            _dataContext.Database.Initialize(true);
            _sut = new HomeController(new ArticleRepository(_dataContext));

        }

        [Test]
        public void Index_ReturnTheModelOfTypeArticle()
        {
            var result = _sut.Index() as ViewResult;
            var model = result.Model as Article;
            
            Assert.IsInstanceOf<Article>(model);
        }

        [Test]
        public void Index_ReturnTheLatestArticle()
        {
            var result = _sut.Index() as ViewResult;
            var model = result.Model as Article;
    
            Assert.AreEqual(10, model.ArticleId);
        }

        [Test]
        public void ArticleDetails_ReturnTheModelOfTypeArticle()
        {
            var result = _sut.ArticleDetails(5) as ViewResult;
            var model = result.Model as Article;

            Assert.IsInstanceOf<Article>(model);    
        }

        [Test]
        public void ArticleDetails_ReturnTheCorrectArticleAsRequestedById()
        {
            var result = _sut.ArticleDetails(5) as ViewResult;
            var model = result.Model as Article;

            Assert.AreEqual(5, model.ArticleId);    
        }

        [Test]
        public void ArticleDetails_ReturnHttpNotFoundIfArticleByIdDoesnotExist()
        {
            var result = _sut.ArticleDetails(25) as HttpNotFoundResult;

            Assert.AreEqual(404, result.StatusCode);    
        }

        [Test]
        public void ArticleSummary_ReturnTheModelOfTypeListOfArticle()
        {
            var result = _sut.ArticleSummary("Category One") as ViewResult;
            var model = result.Model as List<Article>;

            Assert.IsInstanceOf<List<Article>>(model);    
        }

        [Test]
        public void ArticleSummary_ReturnAListOfArticlesByCategory()
        {
            var result = _sut.ArticleSummary("Category One") as ViewResult;
            var model = result.Model as List<Article>;

            Assert.AreEqual(3, model.Count);
        }

        [Test]
        public void ArticleSummary_ReturnHttpNotFoundIfArticleByIdDoesnotExist()
        {
            var result = _sut.ArticleSummary("Test Value") as HttpNotFoundResult;

            Assert.AreEqual(404, result.StatusCode);
        }

        [Test]
        public void Archive_ReturnTheCorrectGroupingModelType()
        {
            var result = _sut.Archive() as ViewResult;
            var model = result.Model as IEnumerable<IGrouping<int, Article>>;

            Assert.IsInstanceOf<IEnumerable<IGrouping<int, Article>>>(model);    
        }

        [Test]
        public void Archive_ReturnArticlesGroupedCorrectly()
        {
            var resul = _sut.Archive() as ViewResult;
            var model = resul.Model as IEnumerable<IGrouping<int, Article>>;

            IEnumerable<Article> result = model.SelectMany(x => x);

            Assert.AreEqual(5, result.Count(x => x.DatePublished.Year == 2013));
            Assert.AreEqual(3, result.Count(x => x.DatePublished.Year == 2012));
            Assert.AreEqual(2, result.Count(x => x.DatePublished.Year == 2011));           
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
