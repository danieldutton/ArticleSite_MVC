using ArticleSite.Model.Entities;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArticleSite._UnitTests.Model.Entities
{
    [TestFixture]
    public class Category_Should
    {
        [Test]
        public void Name_RegisterAModelErrorIfNameValueIsAnEmptyString()
        {
            var sut = new Category { Name = string.Empty };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount); 
        }

        [Test]
        public void Name_GenerateTheCorrectErrorMessageIfNameValueIsAnEmptyString()
        {
            var sut = new Category { Name = string.Empty };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Category name is required", errorMessage);    
        }

        [Test]
        public void Name_RegisterAModelErrorIfNameValueIsNull()
        {
            var sut = new Category { Name = string.Empty };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Name_GenerateTheCorrectErrorMessageIfNameValueIsNull()
        {
            var sut = new Category { Name = string.Empty };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Category name is required", errorMessage);
        }

        [Test]
        public void Name_RegisterAModelErrorIfNameValueIsMoreThan70Chars()
        {
            var chars71 = new string('a', 71);
            var sut = new Category { Name = chars71 };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);        
        }

        [Test]
        public void Name_GenerateTheCorrectErrorMessageIfNameIsMoreThan70Chars()
        {
            var chars71 = new string('a', 71);

            var sut = new Category { Name = chars71 };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Category max 70 characters", errorMessage);   
        }
    }
}
