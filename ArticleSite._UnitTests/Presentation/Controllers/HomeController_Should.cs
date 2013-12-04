using ArticleSite.Presentation.Controllers;
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
            var homeController = new HomeController();

            ViewResult vr = homeController.Index();

            Assert.AreEqual(string.Empty, vr.ViewName);
        }

        [Test]
        public void About_ReturnTheCorrectView()
        {
            var homeController = new HomeController();

            ViewResult vr = homeController.Index();

            Assert.AreEqual(string.Empty, vr.ViewName);
        }

        [Test]
        public void Contact_ReturnTheCorrectView()
        {
            var homeController = new HomeController();

            ViewResult vr = homeController.Index();

            Assert.AreEqual(string.Empty, vr.ViewName);
        }
    }
}
