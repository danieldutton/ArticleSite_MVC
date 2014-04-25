using ArticleSite.Services;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArticleSite._UnitTests.Services
{
    class Contact_Should
    {
        private const string NameValue = "Name";

        private const string SubjectValue = "Subject";

        private const string EmailValue = "dan@dan.com";

        private const string MessageValue = "Message";

        [Test]
        public void Name_FailModelValidation_IfNameIsAnEmptyString()
        {
            var sut = new Contact { Name = string.Empty, Subject = SubjectValue, Email = EmailValue, Message = MessageValue };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Name_GenerateTheCorrectErrorMessage_IfNameIsAnEmptyString()
        {
            var sut = new Contact { Name = string.Empty, Subject = SubjectValue, Email = EmailValue, Message = MessageValue };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Name is required", errorMessage);
        }

        [Test]
        public void Name_FailModelValidation_IfNameIsMissing()
        {
            var sut = new Contact { Name = null, Subject = SubjectValue, Email = EmailValue, Message = MessageValue };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Name_GenerateTheCorrectErrorMessage_IfNameIsMissing()
        {
            var sut = new Contact { Name = null, Subject = SubjectValue, Email = EmailValue, Message = MessageValue };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Name is required", errorMessage);
        }

        [Test]
        public void Name_ErrorMessageDisplayed_IfCharsOver70()
        {
            var chars71 = new string('a', 71);

            var sut = new Contact { Name = chars71, Subject = SubjectValue, Email = EmailValue, Message = MessageValue };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Max of 70 characters allowed", errorMessage);
        }
       
        [Test]
        public void Subject_FailModelValidation_IfSubjectIsAnEmptyString()
        {
            var sut = new Contact { Name = NameValue, Subject = string.Empty, Email = EmailValue, Message = MessageValue };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Subject_GenerateTheCorrectErrorMessage_IfSubjectIsAnEmptyString()
        {
            var sut = new Contact { Name = NameValue, Subject = string.Empty, Email = EmailValue, Message = MessageValue };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Subject is required", errorMessage);
        }

        [Test]
        public void Subject_FailModelValidation_IfSubjectIsMissing()
        {
            var sut = new Contact { Name = NameValue, Subject = null, Email = EmailValue, Message = MessageValue };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Subject_GenerateTheCorrectErrorMessage_IfSubjectIsMissing()
        {
            var sut = new Contact { Name = NameValue, Subject = null, Email = EmailValue, Message = MessageValue };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Subject is required", errorMessage);
        }

        [Test]
        public void Subject_ErrorMessageDisplayed_IfCharsOver70()
        {
            var chars71 = new string('a', 71);

            var sut = new Contact { Name = NameValue, Subject = chars71, Email = EmailValue, Message = MessageValue };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Max of 70 characters allowed", errorMessage);
        }

        //
        [Test]
        public void Email_FailModelValidation_IfEmailIsAnEmptyString()
        {
            var sut = new Contact { Name = NameValue, Subject = SubjectValue, Email = string.Empty, Message = MessageValue };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Email_GenerateTheCorrectErrorMessage_IfEmailIsAnEmptyString()
        {
            var sut = new Contact { Name = NameValue, Subject = SubjectValue, Email = string.Empty, Message = MessageValue };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Email is required", errorMessage);
        }

        [Test]
        public void Email_FailModelValidation_IfEmailIsMissing()
        {
            var sut = new Contact { Name = NameValue, Subject = SubjectValue, Email = null, Message = MessageValue };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Email_GenerateTheCorrectErrorMessage_IfEmailIsMissing()
        {
            var sut = new Contact { Name = NameValue, Subject = SubjectValue, Email = null, Message = MessageValue };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Email is required", errorMessage);
        }

        [Test]
        public void Email_ErrorMessageDisplayed_IfCharsOver70()
        {
            var chars71 = new string('a', 71);

            var sut = new Contact { Name = NameValue, Subject = SubjectValue, Email = chars71, Message = MessageValue };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Max of 70 characters allowed", errorMessage);
        }
       
        [Test]
        public void Message_FailModelValidation_IfMessageIsAnEmptyString()
        {
            var sut = new Contact { Name = NameValue, Subject = SubjectValue, Email = EmailValue, Message = string.Empty };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Message_GenerateTheCorrectErrorMessage_IfMessageIsAnEmptyString()
        {
            var sut = new Contact { Name = NameValue, Subject = SubjectValue, Email = EmailValue, Message = string.Empty };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Message is required", errorMessage);
        }

        [Test]
        public void Message_FailModelValidation_IfMessageIsMissing()
        {
            var sut = new Contact { Name = NameValue, Subject = SubjectValue, Email = EmailValue, Message = null };

            int errorCount = Mother.ValidateModel(sut).Count;

            Assert.AreEqual(1, errorCount);
        }

        [Test]
        public void Message_GenerateTheCorrectErrorMessage_IfMessageIsMissing()
        {
            var sut = new Contact { Name = NameValue, Subject = SubjectValue, Email = EmailValue, Message = null };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Message is required", errorMessage);
        }

        [Test]
        public void Message_ErrorMessageDisplayed_IfCharsOver500()
        {
            var chars501 = new string('a', 501);

            var sut = new Contact { Name = NameValue, Subject = SubjectValue, Email = EmailValue, Message = chars501 };

            IList<ValidationResult> result = Mother.ValidateModel(sut);
            string errorMessage = result[0].ErrorMessage;

            Assert.AreEqual("Max of 500 characters allowed", errorMessage);
        }
    }
}
