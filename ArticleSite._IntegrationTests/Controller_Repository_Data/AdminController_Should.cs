using ArticleSite.DataAccess;
using ArticleSite.Model.Entities;
using ArticleSite.Presentation.Controllers;
using ArticleSite.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Web.Mvc;

namespace ArticleSite._IntegrationTests.Controller_Repository_Data
{
    [TestFixture]
    public class AdminController_Should
    {
        private const string DbFile = "ArticleSite.DataAccess.ArticleDbContext";

        private ArticleDbContext _dataContext;

        private AdminController _sut;

        [SetUp]
        public void InitTest()
        {
            Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0", "",
                    string.Format("Data Source=\"{0}\";", DbFile));
            Database.SetInitializer(new ArticleDataInitialiser());

            _dataContext = new ArticleDbContext();
            _dataContext.Database.Initialize(true);
            _sut = new AdminController(new ArticleRepository(_dataContext));

        }

        [Test]
        public void Index_ReturnTheModelOfTypeListOfArticle()
        {
            var vieResult = _sut.Index() as ViewResult;
            var model = vieResult.Model as List<Article>;

            Assert.IsInstanceOf<List<Article>>(model);
        }

        [Test]
        public void Index_ReturnTheCorrectCountOfArticles()
        {
            var viewResult = _sut.Index() as ViewResult;
            var model = viewResult.Model as List<Article>;

            Assert.AreEqual(10, model.Count);
        }

        [Test]
        public void Details_ReturnTheModelOfTypeArticle()
        {
            var viewResult = _sut.Details(1) as ViewResult;
            var model = viewResult.Model as Article;

            Assert.IsInstanceOf<Article>(model);    
        }

        [Test]
        public void Details_ReturnTheCorrectArticleById()
        {
            var viewResult = _sut.Details(1) as ViewResult;
            var model = viewResult.Model as Article;

            Assert.AreEqual(1, model.ArticleId);    
        }

        [Test]
        public void Details_ReturnHttpNotFoundIfArticleDoesntExist()
        {
            var viewResult = _sut.Details(25) as HttpNotFoundResult;

            Assert.AreEqual(404, viewResult.StatusCode);   
        }

        [Test]
        public void Create_CreateANewArticleIfModelStateIsValid()
        {
            var article = new Article
                {
                    DatePublished = new DateTime(2013, 2, 4),
                    Title = "Title 1",
                    Content = "Content 1"
                };
           
            _sut.Create(article);
            
            var viewResult = _sut.Details(11) as ViewResult;
            var a = viewResult.Model as Article;

            Assert.AreEqual(11, a.ArticleId);
            Assert.AreEqual("Title 1", a.Title);
        }

        [Test]
        public void Create_FailToCreateANewArticleIfModelStateIsInvalid()
        {
            var article = new Article
            {
                DatePublished = new DateTime(2013, 2, 4),
                Title = null,
                Content = null
            };
            _sut.ModelState.AddModelError("Title", "Required");
            _sut.Create(article);

            var viewResult = _sut.ArticleRepository.All;
            
            Assert.IsTrue(viewResult.Count == 10);
        }

        [Test]
        public void Create_ReturnTheCorrectModelTypeOfArticle()
        {
            var article = new Article
            {
                DatePublished = new DateTime(2013, 2, 4),
                Title = "Title 1",
                Content = "Content 1"
            };

            _sut.Create(article);

            var viewResult = _sut.Details(11) as ViewResult;
            var a = viewResult.Model as Article;

            Assert.IsInstanceOf<Article>(a);    
        }

        [Test]
        public void Edit_EditANewArticleIfModelStateIsValid()
        {
            var viewResultBefore = _sut.Details(1) as ViewResult;
            var art = viewResultBefore.Model as Article;
            art.Title = "Updated Title";

            _sut.Edit(art);

            var viewResultAfter = _sut.Details(1) as ViewResult;
            var a = viewResultAfter.Model as Article;

            Assert.AreEqual(1, a.ArticleId);
            Assert.AreEqual("Updated Title", a.Title);    
        }

        [Test]
        public void Edit_FailToEditANewArticleIfModelStateIsInvalid()
        {
            var viewResultBefore = _sut.Details(1) as ViewResult;
            var art = viewResultBefore.Model as Article;
            art.Title = null;
            _sut.ModelState.AddModelError("Title", "Required");

            _sut.Edit(art);

            var viewResultAfter = _sut.Details(1) as ViewResult;
            var a = viewResultAfter.Model as Article;

            Assert.AreEqual(1, a.ArticleId);
            Assert.AreEqual("Title 1", a.Title );
        }

        [Test]
        public void Edit_ReturnTheCorrectModelTypeOfArticle()
        {
            var viewResultBefore = _sut.Details(1) as ViewResult;
            var art = viewResultBefore.Model as Article;
            art.Title = "Updated Title";

            _sut.Edit(art);

            var viewResultAfter = _sut.Details(1) as ViewResult;
            var a = viewResultAfter.Model as Article;

            Assert.IsInstanceOf<Article>(a);
        }

        [Test]
        public void Delete_ReturnTheCorrectModelTypeOfArticle()
        {
            var viewResult =_sut.Delete(1) as ViewResult;
            var model = viewResult.Model as Article;

            Assert.IsInstanceOf<Article>(model);
        }

        [Test]
        public void Delete_ReturnHttpNotFoundIfArticleDoesntExist()
        {
            var viewResult = _sut.Details(25) as HttpNotFoundResult;

            Assert.AreEqual(404, viewResult.StatusCode);
        }

        [Test]
        public void DeleteConfirmed_SuccessfullyDeleteAnExistingArticle()
        {
            var viewResult = _sut.DeleteConfirmed(2) as ViewResult;

            var article = viewResult.Model as Article;

            var counter = _sut.Details(2);
            var articles = _sut.ArticleRepository.All;
            Assert.IsNull(counter);
            Assert.AreEqual(9, articles.Count);
        }

        [Test]
        public void DeleteConfirmed_PerformNoDeleteOperationIfArticleCannotBeFound()
        {
            var viewResult = _sut.DeleteConfirmed(25) as ViewResult;

            var article = viewResult.Model as Article;
            var articles = _sut.ArticleRepository.All;

            Assert.IsNull(article);
            Assert.AreEqual(10, articles.Count);
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
