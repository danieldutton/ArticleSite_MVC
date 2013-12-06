using ArticleSite.Model.Entities;
using ArticleSite.Presentation.Controllers;
using ArticleSite.Repository.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ArticleSite._UnitTests.Presentation.Controllers
{
    [TestFixture]
    public class AdminController_Should
    {
        [Test]
        public void Index_CallArticleRepositoryAllMethodExactlyOnce()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            var sut = new AdminController(fakeArticleRepository.Object);

            sut.Index();

            fakeArticleRepository.Verify(x => x.All, Times.Once());    
        }

        [Test]
        public void Index_ReturnTheCorrectViewIfModelIsNotNull()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            fakeArticleRepository.Setup(x => x.All).Returns(() => new List<Article>());           
            var sut = new AdminController(fakeArticleRepository.Object);

            var viewResult = sut.Index() as ViewResult;

            Assert.AreEqual(string.Empty, viewResult.ViewName);
        }

        [Test]
        public void Index_ReturnHttpNotFoundIfModelIsNull()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            fakeArticleRepository.SetupGet(x => x.All).Returns(() => null);
            var sut = new AdminController(fakeArticleRepository.Object);

            var viewResult = sut.Index() as HttpNotFoundResult;

            Assert.AreEqual(404, viewResult.StatusCode);   
        }

        [Test]
        public void Index_ReturnTheCorrectModelType()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            fakeArticleRepository.Setup(x => x.All).Returns(() => new List<Article>());
            var sut = new AdminController(fakeArticleRepository.Object);

            var viewResult = sut.Index() as ViewResult;
            var model = viewResult.Model;

            Assert.IsInstanceOf<List<Article>>(model);    
        }

        [Test]
        public void Details_CallArticleRepositoryFindMethodExactlyOnce()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            var sut = new AdminController(fakeArticleRepository.Object);

            sut.Details(1);

            fakeArticleRepository.Verify(x => x.Find(1), Times.Once());    
        }

        [Test]
        public void Details_ReturnTheCorrectViewIfModelStateIsNotNull()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            fakeArticleRepository.Setup(x => x.Find(It.IsAny<int>())).Returns(() => new Article());
            var sut = new AdminController(fakeArticleRepository.Object);

            var viewResult = sut.Details() as ViewResult;

            Assert.AreEqual(string.Empty, viewResult.ViewName);    
        }

        [Test]
        public void Details_ReturnHttpNotFoundIfModelIsNull()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            fakeArticleRepository.Setup(x => x.Find(It.IsAny<int>())).Returns(() => null);
            var sut = new AdminController(fakeArticleRepository.Object);

            var viewResult = sut.Details() as HttpNotFoundResult;

            Assert.AreEqual(404, viewResult.StatusCode);    
        } 

        [Test]
        public void Details_ReturnTheCorrectModelType()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            fakeArticleRepository.Setup(x => x.Find(1)).Returns(() => new Article());
            var sut = new AdminController(fakeArticleRepository.Object);

            var viewResult = sut.Details(1) as ViewResult;
            var model = viewResult.Model as Article;

            Assert.IsInstanceOf<Article>(model);     
        }

        [Test]
        public void Create_Get_ReturnTheCorrectView()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            var sut = new AdminController(fakeArticleRepository.Object);

            var viewResult = sut.Create() as ViewResult;

            Assert.AreEqual(string.Empty, viewResult.ViewName);    
        }

        [Test]
        public void Create_Post_ReturnTheCorrectViewIfModelStateIsInvalid()
        {
            var invalidArticle = new Article {Content = "Test Content"};

            var fakeArticleRepository = new Mock<IArticleRepository>();
            var sut = new AdminController(fakeArticleRepository.Object);
            
            Mother.ValidateViewModel(invalidArticle, sut);
            var viewResult = sut.Create(invalidArticle) as ViewResult;

            Assert.AreEqual(string.Empty, viewResult.ViewName);
        }


        [Test]
        public void Create_Post_IfArticleStateIsValidCallAddMethodOnce()
        {
            var validArticle = new Article { DatePublished = DateTime.Now, Title = "Valid Title", Content = "Valid Content"};
            var fakeArticleRepository = new Mock<IArticleRepository>();
            var sut = new AdminController(fakeArticleRepository.Object);

            sut.Create(validArticle);

            fakeArticleRepository.Verify(x => x.Add(validArticle), Times.Once());

        }

        [Test]
        public void Create_Post_IfArticleStateIsValidRedirectToIndexView()
        {
            var validArticle = new Article { DatePublished = DateTime.Now, Title = "Valid Title", Content = "Valid Content" };
            var fakeArticleRepository = new Mock<IArticleRepository>();
            var sut = new AdminController(fakeArticleRepository.Object);

            var redirectResult = sut.Create(validArticle) as RedirectToRouteResult;

            Assert.AreEqual("Index", redirectResult.RouteValues["action"]);
        }

        [Test]
        public void Edit_Get__CallArticleRepositoryFindMethodOnce()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            var sut = new AdminController(fakeArticleRepository.Object);

            sut.Edit(1);

            fakeArticleRepository.Verify(x => x.Find(1), Times.Once());      
        }

        [Test]
        public void Edit_Get_ReturnHttpNotFoundIfModelIsNull()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            fakeArticleRepository.Setup(x => x.Find(0)).Returns(() => null);
            var sut = new AdminController(fakeArticleRepository.Object);

            var viewResult = sut.Edit() as HttpNotFoundResult;

            Assert.AreEqual(404, viewResult.StatusCode);    
        }

        [Test]
        public void Edit_Get_ReturnTheCorrectViewIfArticleIsNotNull()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            fakeArticleRepository.Setup(x => x.Find(1)).Returns(() => new Article());
            var sut = new AdminController(fakeArticleRepository.Object);

            var viewResult = sut.Edit(1) as ViewResult;

            Assert.AreEqual(string.Empty, viewResult.ViewName);       
        }

        [Test]
        public void Edit_Post_IfArticleStateIsValidCallUpdateMethodOnce()
        {
            var validArticle = new Article { DatePublished = DateTime.Now, Title = "Valid Title", Content = "Valid Content" };
            var fakeArticleRepository = new Mock<IArticleRepository>();
            fakeArticleRepository.Setup(x => x.Update(validArticle));
            var sut = new AdminController(fakeArticleRepository.Object);

            sut.Edit(validArticle);

            fakeArticleRepository.Verify(x => x.Update(It.IsAny<Article>()), Times.Once());    
        }

        [Test]
        public void Edit_Post_IfArticleStateIsValidRedirectToIndexView()
        {
            var validArticle = new Article { DatePublished = DateTime.Now, Title = "Valid Title", Content = "Valid Content" };
            var fakeArticleRepository = new Mock<IArticleRepository>();
            var sut = new AdminController(fakeArticleRepository.Object);

            var redirectResult = sut.Edit(validArticle) as RedirectToRouteResult;

            Assert.AreEqual("Index", redirectResult.RouteValues["action"]);
        }

        [Test]
        public void Edit_Post_IfArticleStateIsInvalidReturnTheCorrectView()
        {
            var invalidArticle = new Article { Content = "Test Content" };
            var fakeArticleRepository = new Mock<IArticleRepository>();
           
            var sut = new AdminController(fakeArticleRepository.Object);
            Mother.ValidateViewModel(invalidArticle, sut);

            var viewResult = sut.Edit(invalidArticle) as ViewResult;
            
            Assert.AreEqual(string.Empty, viewResult.ViewName);
        }

        [Test]
        public void Delete_CallArticleRepositoryFindMethodOnce()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            var sut = new AdminController(fakeArticleRepository.Object);

            sut.Delete(1);

            fakeArticleRepository.Verify(x => x.Find(1), Times.Once());
        }

        [Test]
        public void Delete_ReturnHttpNotFoundIfArticleIsNull()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            fakeArticleRepository.Setup(x => x.Find(1)).Returns(() => null);
            var sut = new AdminController(fakeArticleRepository.Object);

            var viewResult = sut.Delete(1) as HttpNotFoundResult;

            Assert.AreEqual(404, viewResult.StatusCode);
        }

        [Test]
        public void Delete_ReturnTheCorrectViewIfArticleIsNotNull()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            fakeArticleRepository.Setup(x => x.Find(1)).Returns(() => new Article());
            var sut = new AdminController(fakeArticleRepository.Object);

            var viewResult = sut.Delete(1) as ViewResult;

            Assert.AreEqual(string.Empty, viewResult.ViewName);
        }


        [Test]
        public void DeleteConfirmed_CallArticleRepositoryFindMethodOnce()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            var sut = new AdminController(fakeArticleRepository.Object);

            sut.DeleteConfirmed(1);

            fakeArticleRepository.Verify(x => x.Find(1), Times.Once());    
        }

        [Test]
        public void DeleteConfirmed_IfArticleIsNotNullCallArticleRepositoryDeleteMethodOnce()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            var sut = new AdminController(fakeArticleRepository.Object);

            sut.DeleteConfirmed(1);

            fakeArticleRepository.Verify(x => x.Find(1), Times.Once());     
        }

        [Test]
        public void DeleteConfirmed_IfArticleIsNullDontCallArticleRepositoryAtAll()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            var sut = new AdminController(fakeArticleRepository.Object);

            sut.DeleteConfirmed(1);

            fakeArticleRepository.Verify(x => x.Delete(It.IsAny<Article>()), Times.Never());
        }

        [Test]
        public void DeleteConfirmed_IfModelStateIsNotNullRedirectToIndexActionAndReturnTheCorrectView()
        {           
            var fakeArticleRepository = new Mock<IArticleRepository>();
            fakeArticleRepository.Setup(x => x.Find(It.IsAny<int>())).Returns(new Article());

            var sut = new AdminController(fakeArticleRepository.Object);

            var redirectResult = sut.DeleteConfirmed(1) as RedirectToRouteResult;

            Assert.AreEqual("Index", redirectResult.RouteValues["action"]);    
        }

        [Test]
        public void DeleteConfirmed_IfModelStateIsNullRedirectToIndexActionAndReturnTheCorrectView()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            fakeArticleRepository.Setup(x => x.Find(1)).Returns(() => null);
            var sut = new AdminController(fakeArticleRepository.Object);

            var redirectResult = sut.DeleteConfirmed(1) as RedirectToRouteResult;

            Assert.AreEqual("Index", redirectResult.RouteValues["action"]); 
        }

    }
}
