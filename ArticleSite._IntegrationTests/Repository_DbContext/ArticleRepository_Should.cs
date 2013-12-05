using ArticleSite.DataAccess;
using ArticleSite.Model.Entities;
using ArticleSite.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;

namespace ArticleSite._IntegrationTests.Repository_DbContext
{
    [TestFixture]
    public class ArticleRepository_Should
    {
        private const string DbFile = "ArticleSite.DataAccess.ArticleDbContext";
        
        private ArticleDbContext _dataContext;

        private ArticleRepository _sut;

        [SetUp]
        public void InitTest()
        {
            Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0", "",
                    string.Format("Data Source=\"{0}\";", DbFile));
            Database.SetInitializer(new DataInitialiser());

            _dataContext = new ArticleDbContext();
            _dataContext.Database.Initialize(true);
            _sut = new ArticleRepository(_dataContext);
        }

        [Test]
        public void All_ReturnAllArticles()
        {
            List<Article> result = _sut.All;

            Assert.AreEqual(10, result.Count);
        }

        [Test]
        public void Find_FindCorrectArticleById()
        {
            Article result = _sut.Find(3);

            Assert.IsTrue(result.Id == 3);
        }

        [Test]
        public void Find_ReturnNullIfAnArticleWithAMatchingIdDoesNotExist()
        {
            Article result = _sut.Find(13);

            Assert.IsTrue(result == null);
        }

        [Test]
        public void Add_AddANewArticleToTheDatabase()
        {
            var article = new Article {DatePublished = DateTime.Now, Title = "New Title", Content = "New Content"};

            _sut.Add(article);
            Article newArticle = _sut.Find(11);

            Assert.AreEqual(11, newArticle.Id);
            Assert.AreEqual("New Title", newArticle.Title);
        }

        [Test]
        public void Update_UpdateARecordInTheDatabase()
        {
            Article result = _sut.Find(3);
            result.Title = "Updated Title";
            _sut.Update(result);
            Article updatedResult = _sut.Find(3);

            Assert.AreEqual("Updated Title", updatedResult.Title);    
        }

        [Test]
        public void Delete_DeleteARecordInTheDatabase()
        {
            Article result = _sut.Find(3);
            _sut.Delete(result);
            Article deletedResult = _sut.Find(3);

            Assert.IsTrue(deletedResult == null);   
        }

        [Test]
        public void LatestArticle_ReturnTheMostRecentArticleByDatePublished()
        {
            var expected = new DateTime(2013, 9, 18);
            Article result = _sut.LatestArticle();

            Assert.AreEqual(expected, result.DatePublished);
        }

        [Test]
        public void LatestArticles_ReturnTheMostRecentArticleListByDatePublished()
        {
            List<Article> result = _sut.LatestArticles(3);

            Assert.AreEqual(3, result.Count);
        }

        [Test]
        public void LatestArticles_ReturnsCorrectMostRecentArticlesByLatestDate()
        {
            List<Article> result = _sut.LatestArticles(3);
            
            var expected1 = new DateTime(2013, 9, 18);
            var expected2 = new DateTime(2013, 9, 14);
            var expected3 = new DateTime(2013, 6, 7);

            Assert.AreEqual(expected1, result[0].DatePublished);
            Assert.AreEqual(expected2, result[1].DatePublished);
            Assert.AreEqual(expected3, result[2].DatePublished);
        }

        [Test]
        public void ArticlesByCategory_ReturnArticleWhereOneSingleCategoryExists()
        {
            List<Article> result = _sut.ArticlesByCategory("Category One");

            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void ArticlesByCategory_ReturnArticlesWhereManyPostsHoldTheSameCategory()
        {
            List<Article> result = _sut.ArticlesByCategory("Category Five");

            Assert.AreEqual(3, result.Count);
        }

        [Test]
        public void ArticlesByCategory_ReturnNullWhenACategoryDoesNotAlreadyExist()
        {
            List<Article> result = _sut.ArticlesByCategory("Category Whatever");

            Assert.AreEqual(0, result.Count);
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
