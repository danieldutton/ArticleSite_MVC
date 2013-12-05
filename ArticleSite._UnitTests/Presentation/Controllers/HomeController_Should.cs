using System.Collections.Generic;
using ArticleSite.Model.Entities;
using ArticleSite.Presentation.Controllers;
using ArticleSite.Repository.Interfaces;
using Moq;
using NUnit.Framework;
using System.Web.Mvc;

namespace ArticleSite._UnitTests.Presentation.Controllers
{
    [TestFixture]
    public class HomeController_Should
    {
        [Test]
        public void Index_ReturnTheCorrectView()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            var homeController = new HomeController(fakeArticleRepository.Object);

            ViewResult vr = homeController.Index();

            Assert.AreEqual(string.Empty, vr.ViewName);
        }

        [Test]
        public void Index_CallArticleRepository_All_ExactlyOnce()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            var homeController = new HomeController(fakeArticleRepository.Object);

            homeController.Index();
            
            fakeArticleRepository.Verify(x => x.All, Times.Once());   
        }

        [Test]
        public void Index_ReturnTheCorrectModelType()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            fakeArticleRepository.Setup(x => x.All).Returns(() => new List<Article>());
            var homeController = new HomeController(fakeArticleRepository.Object);

            var model = homeController.Index().Model as List<Article>;

            CollectionAssert.AllItemsAreInstancesOfType(model, typeof (List<Article>));
        }

        [Test]
        public void About_ReturnTheCorrectView()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            var homeController = new HomeController(fakeArticleRepository.Object);

            ViewResult vr = homeController.Index();

            Assert.AreEqual(string.Empty, vr.ViewName);
        }

        [Test]
        public void Contact_ReturnTheCorrectView()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            var homeController = new HomeController(fakeArticleRepository.Object);

            ViewResult vr = homeController.Index();

            Assert.AreEqual(string.Empty, vr.ViewName);
        }
    }
}
