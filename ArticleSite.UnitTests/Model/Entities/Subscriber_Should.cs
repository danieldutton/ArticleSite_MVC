using ArticleSite.Model.Entities;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArticleSite.UnitTests.Model.Entities
{
    [TestFixture]
    public class Subscriber_Should
    {
        [Test]
        public void Email_RegisterAModelError_IfEmailIsEmptyString()
        {
            var sut = new Subscriber {Email = string.Empty};

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Email_GenerateCorrectErrorMessage_IfEmailIsEmptyString()
        {
            var sut = new Subscriber {Email = string.Empty};

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Email is required", errorMessage);
        }

        [Test]
        public void Email_RegisterAModelError_IfEmailIsNull()
        {
            var sut = new Subscriber { Email = null };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Email_GenerateCorrectErrorMessage_IfEmailIsNull()
        {
            var sut = new Subscriber { Email = null };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Email is required", errorMessage);
        }

        [Test]
        public void Email_RegisterAModelError_IfEmailGreaterThan254Chars()
        {
            var chars255 = new string('a', 255);
            var sut = new Subscriber {Email = chars255};

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Email_GenerateCorrectErrorMessage_IfEmailGreaterThan254Chars()
        {
            var chars255 = new string('a', 255);
            var sut = new Subscriber { Email = chars255 };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Max of 254 characters", errorMessage);
        }

        [Test]
        public void Email_RegisterNoModelErrors_IfEmailAddressIsValid()
        {
            var sut = new Subscriber { Email = "danielbdutton@mail.com" };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(0, errorCount);
        }

        [Test]
        public void Email_RegisterAModelError_IfEmailAddressInvalid()
        {
            var sut = new Subscriber { Email = "danD_._com" };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Email_GenerateCorrectErrorMessage_IfEmailAddressInvalid()
        {
            var sut = new Subscriber { Email = "danD_com" };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Category max 70 characters", errorMessage);
        }
    }
}
