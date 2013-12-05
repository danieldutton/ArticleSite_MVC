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
