using ArticleSite.Model.Entities;
using ArticleSite.Presentation.Controllers;
using ArticleSite.Repository.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ArticleSite._UnitTests.Presentation.Controllers
{
    [TestFixture]
    public class HomeController_Should
    {
        [Test]
        public void Index_CallArticleRepository_LatestArticle_ExactlyOnce()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            var homeController = new HomeController(fakeArticleRepository.Object);

            homeController.Index();

            fakeArticleRepository.Verify(x => x.LatestArticle(), Times.Once());
        }

        [Test]
        public void Index_ReturnTheCorrectView()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            fakeArticleRepository.Setup(x => x.LatestArticle()).Returns(new Article());
            var homeController = new HomeController(fakeArticleRepository.Object);

            var viewResult = homeController.Index() as ViewResult;

            Assert.AreEqual(string.Empty, viewResult.ViewName);
        }

        [Test]
        public void Index_ReturnHttpNotFoundIfArticlesDataIsNull()
        {
            var fakeRepository = new Mock<IArticleRepository>();
            fakeRepository.Setup(x => x.LatestArticle()).Returns(()=> null);
            var homeController = new HomeController(fakeRepository.Object);

            var result = homeController.Index() as HttpNotFoundResult;

            Assert.AreEqual(404, result.StatusCode);
        }

        [Test]
        public void Index_ReturnTheCorrectModelType()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            fakeArticleRepository.Setup(x => x.LatestArticle()).Returns(() => new Article());
            var homeController = new HomeController(fakeArticleRepository.Object);

            var viewResult = homeController.Index() as ViewResult;
            var model = viewResult.Model as Article;

            Assert.IsInstanceOf<Article>(model);
        }

        [Test]
        public void About_ReturnTheCorrectView()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            var homeController = new HomeController(fakeArticleRepository.Object);

            var viewResult = homeController.About() as ViewResult;

            Assert.AreEqual(string.Empty, viewResult.ViewName);
        }

        [Test]
        public void ArticleDetails_CallArticleRepository_Find_ExactlyOnce()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            var homeController = new HomeController(fakeArticleRepository.Object);

            homeController.ArticleDetails(1);

            fakeArticleRepository.Verify(x => x.Find(1), Times.Once());    
        }

        [Test]
        public void ArticleDetails_ReturnTheCorrectView()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            fakeArticleRepository.Setup(x => x.Find(1)).Returns(() => new Article());
            var homeController = new HomeController(fakeArticleRepository.Object);

            var viewResult = homeController.ArticleDetails(1) as ViewResult;

            Assert.AreEqual(string.Empty, viewResult.ViewName);
        }

        [Test]
        public void ArticleDetails_ReturnHttpNotFoundIfArticlesDataIsNull()
        {
            var fakeRepository = new Mock<IArticleRepository>();
            fakeRepository.SetupGet(x => x.All).Returns(() => null);
            var homeController = new HomeController(fakeRepository.Object);

            var result = homeController.ArticleDetails(1) as HttpNotFoundResult;

            Assert.AreEqual(404, result.StatusCode);
        }

        [Test]
        public void ArticleDetails_ReturnTheCorrectModelType()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            fakeArticleRepository.Setup(x => x.Find(1)).Returns(() => new Article());
            var homeController = new HomeController(fakeArticleRepository.Object);

            var viewResult = homeController.ArticleDetails(1) as ViewResult;
            var model = viewResult.Model as Article;

            Assert.IsInstanceOf<Article>(model);   
        }

        [Test]
        public void ArticleSummary_CallArticleRepository_ArticlesByCategory_ExactlyOnce()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            fakeArticleRepository.Setup(x => x.ArticlesByCategory(It.IsAny<string>())).Returns(()=> new List<Article>());
            var homeController = new HomeController(fakeArticleRepository.Object);

            homeController.ArticleSummary(It.IsAny<string>());

            fakeArticleRepository.Verify(x => x.ArticlesByCategory(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void ArticleSummary_ReturnTheCorrectView()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            fakeArticleRepository.Setup(x => x.ArticlesByCategory(It.IsAny<string>())).Returns(() => new List<Article>());
            var homeController = new HomeController(fakeArticleRepository.Object);

            var viewResult = homeController.ArticleSummary(It.IsAny<string>()) as ViewResult;

            Assert.AreEqual(string.Empty, viewResult.ViewName);
        }

        [Test]
        public void ArticleSummary_ReturnHttpNotFoundIfArticlesByCategoryDataIsNull()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            fakeArticleRepository.Setup(x => x.ArticlesByCategory(It.IsAny<string>())).Returns(() => null);
            var homeController = new HomeController(fakeArticleRepository.Object);

            var result = homeController.ArticleSummary(It.IsAny<string>()) as HttpNotFoundResult;

            Assert.AreEqual(404, result.StatusCode);
        }

        [Test]
        public void ArticleSummary_ReturnTheCorrectModelType()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            fakeArticleRepository.Setup(x => x.ArticlesByCategory(It.IsAny<string>())).Returns(() => new List<Article>());
            var homeController = new HomeController(fakeArticleRepository.Object);

            var viewResult = homeController.ArticleSummary(It.IsAny<string>()) as ViewResult;
            var model = viewResult.Model as List<Article>;

            Assert.IsInstanceOf<List<Article>>(model);
        }

        [Test]
        public void Archive_CallArticleRepository_ArticlesGroupedByYear_ExactlyOnce()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            var homeController = new HomeController(fakeArticleRepository.Object);

            homeController.Archive();

            fakeArticleRepository.Verify(x => x.ArticlesGroupedByYear(), Times.Once());
        }

        [Test]
        public void Archive_ReturnHttpNotFoundIfArticlesDataIsNull()
        {
            var fakeRepository = new Mock<IArticleRepository>();
            fakeRepository.Setup(x => x.ArticlesGroupedByYear()).Returns(()=> null);
            var homeController = new HomeController(fakeRepository.Object);

            var result = homeController.Archive() as HttpNotFoundResult;

            Assert.AreEqual(404, result.StatusCode);
        }

        [Test]
        public void Archive_ReturnTheCorrectView()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            var homeController = new HomeController(fakeArticleRepository.Object);

            var viewResult = homeController.Archive() as ViewResult;

            Assert.AreEqual(string.Empty, viewResult.ViewName);
        }

        [Test]
        public void Archive_ReturnTheCorrectModelType()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            fakeArticleRepository.Setup(x => x.Find(1)).Returns(() => new Article());
            var homeController = new HomeController(fakeArticleRepository.Object);

            var viewResult = homeController.Archive() as ViewResult;
            var model = viewResult.Model as IEnumerable<IGrouping<int, Article>>;

            Assert.IsInstanceOf<IEnumerable<IGrouping<int, Article>>>(model); 
        }

        [Test]
        public void Contact_ReturnTheCorrectView()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            var homeController = new HomeController(fakeArticleRepository.Object);

            var viewResult = homeController.Contact() as ViewResult;

            Assert.AreEqual(string.Empty, viewResult.ViewName);
        }
    }
}
