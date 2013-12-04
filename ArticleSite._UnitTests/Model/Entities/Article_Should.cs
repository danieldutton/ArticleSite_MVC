using ArticleSite.Model.Entities;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArticleSite._UnitTests.Model.Entities
{
    [TestFixture]
    public class Article_Should
    {
        private const string TitleValue = "Title";

        private const string ContentValue = "Content";


        [Test]
        public void Title_RegisterAModelErrorIfTitleValueIsAnEmptyString()
        {
            var sut = new Article { Title = string.Empty, Content = ContentValue };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Title_GenerateTheCorrectErrorMessageIfTitleValueIsAnEmptyString()
        {
            var sut = new Article { Title = string.Empty, Content = ContentValue };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Title is required", errorMessage);
        }

        [Test]
        public void Title_RegisterAModelErrorIfTitleValueIsNull()
        {
            var sut = new Article { Title = null, Content = ContentValue };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Title_GenerateTheCorrectErrorMessageIfTitleValueIsNull()
        {
            var sut = new Article { Title = null, Content = ContentValue };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Title is required", errorMessage);
        }

        [Test]
        public void Title_RegisterAModelErrorIfTitleValueIsMoreThan100Chars()
        {
            var chars71 = new string('a', 101);
            var sut = new Article { Title = chars71, Content = ContentValue };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Title_GenerateTheCorrectErrorMessageIfTitleIsMoreThan100Chars()
        {
            var chars71 = new string('a', 101);
            var sut = new Article { Title = chars71, Content = ContentValue };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Title max 70 characters", errorMessage);
        }

        [Test]
        public void Content_RegisterAModelErrorIfContentValueIsAnEmptyString()
        {
            var sut = new Article { Title = TitleValue, Content = string.Empty };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Content_GenerateTheCorrectErrorMessageIfContentValueIsAnEmptyString()
        {
            var sut = new Article { Title = TitleValue, Content = string.Empty };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Content is required", errorMessage);
        }

        [Test]
        public void Content_RegisterAModelErrorIfContentValueIsNull()
        {
            var sut = new Article { Title = TitleValue, Content = null };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Content_GenerateTheCorrectErrorMessageIfContentValueIsNull()
        {
            var sut = new Article { Title = TitleValue, Content = null };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Content is required", errorMessage);
        }

        [Test]
        public void Content_RegisterAModelErrorIfContentValueIsMoreThan6000Chars()
        {
            var chars6001 = new string('a', 6001);
            var sut = new Article { Title = TitleValue, Content = chars6001 };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Content_GenerateTheCorrectErrorMessageIfContentValueIsMoreThan6000Chars()
        {
            var chars6001 = new string('a', 6001);
            var sut = new Article { Title = TitleValue, Content = chars6001 };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Content max 6000 characters", errorMessage);
        }
    }
}
