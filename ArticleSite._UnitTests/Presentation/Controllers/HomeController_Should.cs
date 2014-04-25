using ArticleSite.Model.Entities;
using ArticleSite.Presentation.Controllers;
using ArticleSite.Repository.Interfaces;
using ArticleSite.Services;
using ArticleSite.Services.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ArticleSite._UnitTests.Presentation.Controllers
{
    [TestFixture]
    public class HomeController_Should
    {
        private Mock<IArticleRepository> _fakeArticleRepository;

        private Mock<IEmailer> _fakeEmailer;

        private HomeController _sut;

        [SetUp]
        public void Init()
        {
            _fakeArticleRepository = new Mock<IArticleRepository>();
            _fakeEmailer = new Mock<IEmailer>();
            _sut = new HomeController(_fakeArticleRepository.Object);
            _sut.MessagingService = _fakeEmailer.Object;
        }

        [Test]
        public void Index_CallLatestArticle_ExactlyOnce()
        {
            _sut.Index();

            _fakeArticleRepository.Verify(x => x.LatestArticle(), Times.Once());
        }

        [Test]
        public void Index_ReturnTheCorrectView()
        {
            _fakeArticleRepository.Setup(x => x.LatestArticle())
                .Returns(new Article());

            var viewResult = _sut.Index() as ViewResult;

            Assert.AreEqual(string.Empty, viewResult.ViewName);
        }

        [Test]
        public void Index_ReturnHttpNotFound_IfArticleReturnedIsNull()
        {
            _fakeArticleRepository.Setup(x => x.LatestArticle())
                .Returns(() => null);

            var result = _sut.Index() as HttpNotFoundResult;

            Assert.AreEqual(404, result.StatusCode);
        }

        [Test]
        public void Index_ReturnTheCorrectModelType()
        {
            _fakeArticleRepository.Setup(x => x.LatestArticle())
                .Returns(() => new Article());

            var viewResult = _sut.Index() as ViewResult;
            var model = viewResult.Model as Article;

            Assert.IsInstanceOf<Article>(model);
        }

        [Test]
        public void About_ReturnTheCorrectView()
        {
            var viewResult = _sut.About() as ViewResult;

            Assert.AreEqual(string.Empty, viewResult.ViewName);
        }

        [Test]
        public void ArticleDetails_CallFind_ExactlyOnce()
        {
            _sut.ArticleDetails(1);

            _fakeArticleRepository.Verify(x => x.Find(It.Is<int>(y => y == 1)), Times.Once());
        }

        [Test]
        public void ArticleDetails_ReturnTheCorrectView()
        {
            _fakeArticleRepository.Setup(x => x.Find(It.IsAny<int>()))
                .Returns(() => new Article());

            var viewResult = _sut.ArticleDetails(1) as ViewResult;

            Assert.AreEqual(string.Empty, viewResult.ViewName);
        }

        [Test]
        public void ArticleDetails_ReturnHttpNotFoundIfArticleReturnedIsNull()
        {
            _fakeArticleRepository.SetupGet(x => x.All)
                .Returns(() => null);

            var result = _sut.ArticleDetails(1) as HttpNotFoundResult;

            Assert.AreEqual(404, result.StatusCode);
        }

        [Test]
        public void ArticleDetails_ReturnTheCorrectModelType()
        {
            _fakeArticleRepository.Setup(x => x.Find(1))
                .Returns(() => new Article());

            var viewResult = _sut.ArticleDetails(1) as ViewResult;
            var model = viewResult.Model as Article;

            Assert.IsInstanceOf<Article>(model);
        }

        [Test]
        public void ArticleSummary_CallArticlesByCategory_ExactlyOnce()
        {
            _fakeArticleRepository.Setup(x => x.ArticlesByCategory(
                It.IsAny<string>()))
                .Returns(() => new List<Article>());

            _sut.ArticleSummary(It.IsAny<string>());

            _fakeArticleRepository.Verify(x => x.ArticlesByCategory(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void ArticleSummary_ReturnTheCorrectView()
        {
            _fakeArticleRepository.Setup(x => x.ArticlesByCategory(
                It.IsAny<string>()))
                .Returns(() => new List<Article>());

            var viewResult = _sut.ArticleSummary(It.IsAny<string>()) as ViewResult;

            Assert.AreEqual(string.Empty, viewResult.ViewName);
        }

        [Test]
        public void ArticleSummary_ReturnHttpNotFoundIfArticlesReturnedIsNull()
        {
            _fakeArticleRepository.Setup(x => x.ArticlesByCategory(
                It.IsAny<string>()))
                .Returns(() => null);

            var result = _sut.ArticleSummary(It.IsAny<string>()) as HttpNotFoundResult;

            Assert.AreEqual(404, result.StatusCode);
        }

        [Test]
        public void ArticleSummary_ReturnTheCorrectModelType()
        {
            _fakeArticleRepository.Setup(x => x.ArticlesByCategory(
                It.IsAny<string>()))
                .Returns(() => new List<Article>());

            var viewResult = _sut.ArticleSummary(It.IsAny<string>()) as ViewResult;
            var model = viewResult.Model as List<Article>;

            Assert.IsInstanceOf<List<Article>>(model);
        }

        [Test]
        public void Archive_CallArticlesGroupedByYear_ExactlyOnce()
        {
            _sut.Archive();

            _fakeArticleRepository.Verify(x => x.ArticlesGroupedByYear(), Times.Once());
        }

        [Test]
        public void Archive_ReturnHttpNotFoundIfArticlesReturnedIsNull()
        {
            _fakeArticleRepository.Setup(x => x.ArticlesGroupedByYear())
                .Returns(() => null);

            var result = _sut.Archive() as HttpNotFoundResult;

            Assert.AreEqual(404, result.StatusCode);
        }

        [Test]
        public void Archive_ReturnTheCorrectView()
        {
            var viewResult = _sut.Archive() as ViewResult;

            Assert.AreEqual(string.Empty, viewResult.ViewName);
        }

        [Test]
        public void Archive_ReturnTheCorrectModelType()
        {
            _fakeArticleRepository.Setup(x => x.Find(1))
                .Returns(() => new Article());

            var viewResult = _sut.Archive() as ViewResult;
            var model = viewResult.Model as IEnumerable<IGrouping<int, Article>>;

            Assert.IsInstanceOf<IEnumerable<IGrouping<int, Article>>>(model);
        }

        [Test]
        public void Contact_Get_ReturnTheCorrectView()
        {
            var viewResult = _sut.Contact() as ViewResult;

            Assert.AreEqual(string.Empty, viewResult.ViewName);
        }

        [Test]
        public void Contact_Post_ReturnContactFailedView_IfModelStateIsInvalid()
        {
            _sut.ModelState.AddModelError("", "");

            var viewResult = _sut.Contact(It.IsAny<Contact>()) as ViewResult;

            Assert.AreEqual("ContactFailed", viewResult.ViewName);
        }

        [Test]
        public void Contact_Post_CallProperty_Contact_Once_IfModelStateIsValid()
        {
            var contactStub = new Contact
            {
                Name = "Daniel Dutton",
                Email = "dan@dan.com,",
                Subject = "Subject 1",
                Message = "Message 1"
            };

            _sut.Contact(contactStub);

            _fakeEmailer.VerifySet(x => x.Contact = contactStub, Times.Once());
        }

        [Test]
        public void Contact_Post_CallMessage_ExactlyOnce_IfModeStateIsValid()
        {
            _sut.Contact(It.IsAny<Contact>());

            _fakeEmailer.Verify(x => x.Message(), Times.Once());
        }

        [Test]
        public void Contact_Post_RedirectToContactConfirmed_IfModelStateIsValid()
        {
            var redirectResult = (RedirectToRouteResult) _sut.Contact(It.IsAny<Contact>());

            Assert.That(redirectResult.RouteName, Is.EqualTo("ContactConfirmed"));
        }

        [Test]
        public void Contact_Post_RedirectToContactFailed_IfExceptionRaised()
        {
            _fakeEmailer.Setup(x => x.Message()).Throws(new Exception());

            var redirectResult = (RedirectToRouteResult) _sut.Contact(It.IsAny<Contact>());

            Assert.That(redirectResult.RouteName, Is.EqualTo("ContactFailed"));
        }

        [Test]
        public void ContactConfirmed_ReturnTheCorrectView()
        {
            var viewResult = _sut.ContactConfirmed() as ViewResult;

            Assert.AreEqual("ContactConfirmed", viewResult.ViewName);
        }

        [Test]
        public void ContactFailed_ReturnTheCorrectView()
        {
            var viewResult = _sut.ContactFailed() as ViewResult;

            Assert.AreEqual("ContactFailed", viewResult.ViewName);
        }

        [TearDown]
        public void TearDown()
        {
            _fakeArticleRepository = null;
            _fakeEmailer = null;
            _sut = null;
        }
    }
}