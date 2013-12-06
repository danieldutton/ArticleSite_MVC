using System;
using System.Collections.Generic;
using ArticleSite.Model.Entities;
using ArticleSite.Presentation.Controllers;
using ArticleSite.Repository.Interfaces;
using Moq;
using NUnit.Framework;
using System.Web.Mvc;

namespace ArticleSite._IntegrationTests.Controller_Repository_Data
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

            fakeArticleRepository.Verify(x => x.All, Times.Exactly(2));    
        }

        [Test]
        public void Index_ReturnTheCorrectView()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
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

            fakeArticleRepository.Verify(x => x.Find(1), Times.Exactly(2));    
        }

        [Test]
        public void Details_ReturnTheCorrectView()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
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
        public void ReturnTheCorrectModelType()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            var sut = new AdminController(fakeArticleRepository.Object);

            var viewResult = sut.Details(1) as ViewResult;
            var model = viewResult.Model;

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

            fakeArticleRepository.Verify(x => x.Add(validArticle), Times.Exactly(2));

        }

        [Test]
        public void Create_Post_IfArticleStateIsValidRedirectToIndexView()
        {
            var validArticle = new Article { DatePublished = DateTime.Now, Title = "Valid Title", Content = "Valid Content" };
            var fakeArticleRepository = new Mock<IArticleRepository>();
            var sut = new AdminController(fakeArticleRepository.Object);

            var viewResult = sut.Create(validArticle) as ViewResult; 
   
            Assert.AreEqual(string.Empty, viewResult.ViewName);
        }

        [Test]
        public void Edit_Get__CallArticleRepositoryFindMethodOnce()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            var sut = new AdminController(fakeArticleRepository.Object);

            sut.Edit(1);

            fakeArticleRepository.Verify(x => x.Find(1), Times.Exactly(2));      
        }

        [Test]
        public void Edit_Get_ReturnHttpNotFoundIfModelIsNull()
        {
            var fakeArticleRepository = new Mock<IArticleRepository>();
            fakeArticleRepository.Setup(x => x.Find(It.IsAny<int>())).Returns(() => null);
            var sut = new AdminController(fakeArticleRepository.Object);

            var viewResult = sut.Edit() as HttpNotFoundResult;

            Assert.AreEqual(404, viewResult.StatusCode);    
        }

        [Test]
        public void Edit_Get_ReturnTheCorrectViewIfModelStateIsValid()
        {
            var invalidArticle = new Article { Content = "Test Content" };
            var fakeArticleRepository = new Mock<IArticleRepository>();
            var sut = new AdminController(fakeArticleRepository.Object);

            var viewResult = sut.Edit(invalidArticle) as ViewResult;

            Assert.AreEqual(string.Empty, viewResult.ViewName);       
        }

        [Test]
        public void Edit_Post_IfArticleStateIsValidCallUpdateMethodOnce()
        {
            
        }

        [Test]
        public void Edit_Post_IfArticleStateIsValidRedirectToIndexView()
        {

        }

        [Test]
        public void Edit_Post_IfArticleStateIsInvalidReturnTheCorrectView()
        {

        }


        [Test]
        public void DeleteConfirmed_CallArticleRepositoryFindMethodOnce()
        {
            
        }

        [Test]
        public void DeleteConfirmed_CallArticleRepositoryDeleteMethodOnce()
        {
            
        }

        [Test]
        public void RedirectToIndexActionAndReturnTheCorrectView()
        {
            
        }

    }
}
