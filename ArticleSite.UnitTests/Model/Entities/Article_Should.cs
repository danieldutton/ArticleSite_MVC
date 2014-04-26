using ArticleSite.Model.Entities;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArticleSite.UnitTests.Model.Entities
{
    [TestFixture]
    public class Article_Should
    {
        private const string TitleValue = "Title";

        private const string ContentValue = "Content";


        [Test]
        public void Title_RegisterAModelError_IfTitleIsEmptyString()
        {
            var sut = new Article { Title = string.Empty, Content = ContentValue };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Title_GenerateCorrectErrorMessage_IfTitleIsEmptyString()
        {
            var sut = new Article { Title = string.Empty, Content = ContentValue };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Title is required", errorMessage);
        }

        [Test]
        public void Title_RegisterAModelError_IfTitleIsNull()
        {
            var sut = new Article { Title = null, Content = ContentValue };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Title_GenerateCorrectErrorMessage_IfTitleIsNull()
        {
            var sut = new Article { Title = null, Content = ContentValue };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Title is required", errorMessage);
        }

        [Test]
        public void Title_RegisterAModelError_IfTitleGreaterThan100Chars()
        {
            var chars71 = new string('a', 101);
            var sut = new Article { Title = chars71, Content = ContentValue };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Title_GenerateCorrectErrorMessage_IfTitleGreaterThan100Chars()
        {
            var chars71 = new string('a', 101);
            var sut = new Article { Title = chars71, Content = ContentValue };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Title max 70 characters", errorMessage);
        }

        [Test]
        public void Content_RegisterAModelError_IfContentIsEmptyString()
        {
            var sut = new Article { Title = TitleValue, Content = string.Empty };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Content_GenerateCorrectErrorMessage_IfContentIsEmptyString()
        {
            var sut = new Article { Title = TitleValue, Content = string.Empty };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Content is required", errorMessage);
        }

        [Test]
        public void Content_RegisterAModelError_IfContentIsNull()
        {
            var sut = new Article { Title = TitleValue, Content = null };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Content_GenerateCorrectErrorMessage_IfContentIsNull()
        {
            var sut = new Article { Title = TitleValue, Content = null };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Content is required", errorMessage);
        }

        [Test]
        public void Content_RegisterAModelError_IfContentGreaterThan6000Chars()
        {
            var chars6001 = new string('a', 6001);
            var sut = new Article { Title = TitleValue, Content = chars6001 };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Content_GenerateCorrectErrorMessage_IfContentGreaterThan6000Chars()
        {
            var chars6001 = new string('a', 6001);
            var sut = new Article { Title = TitleValue, Content = chars6001 };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Content max 6000 characters", errorMessage);
        }
    }
}
