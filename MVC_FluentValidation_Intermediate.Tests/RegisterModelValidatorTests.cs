using System.Linq;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVC_FluentValidation_Intermediate.Models;
using MVC_FluentValidation_Intermediate.Repositories;
using MVC_FluentValidation_Intermediate.Validators;

namespace MVC_FluentValidation_Intermediate.Tests
{
    [TestClass]
    public class RegisterModelValidatorTests
    {
        [TestMethod]
        public void UserName_When_Null()
        {
            //
            // Arrange
            //
            var mockRepository = new Mock<IRegisterModelRepository>();
            mockRepository.Setup(repository => repository.GetUserProfileByUserName(It.IsAny<string>())).Returns(new RegisterModel());
            var validator = new RegisterModelValidator(mockRepository.Object);
            //
            // Act
            //
            var errors = validator.ShouldHaveValidationErrorFor(x => x.UserName, (string) null);
            //
            // Assert
            //
            Assert.IsNotNull(errors);
            Assert.AreEqual(1, errors.Count());
            Assert.AreEqual("Please provide a user name", errors.First().ErrorMessage);
        }

        [TestMethod]
        public void UserName_When_Empty()
        {
            //
            // Arrange
            //
            var mockRepository = new Mock<IRegisterModelRepository>();
            mockRepository.Setup(repository => repository.GetUserProfileByUserName(It.IsAny<string>())).Returns(new RegisterModel
            {
                UserName = string.Empty
            });
            var validator = new RegisterModelValidator(mockRepository.Object);
            //
            // Act
            //
            var validationResult = validator.Validate(new RegisterModel());
            //
            // Assert
            //
            Assert.IsFalse(validationResult.IsValid);
            Assert.IsTrue(validationResult.Errors.Any(x => x.ErrorMessage == "Please provide a user name"));
        }

        [TestMethod]
        public void UserName_When_Valid()
        {
            var mockRepository = new Mock<IRegisterModelRepository>();
            mockRepository.Setup(repository => repository.GetUserProfileByUserName(It.IsAny<string>())).Returns((RegisterModel) null);
            var validator = new RegisterModelValidator(mockRepository.Object);
            validator.ShouldNotHaveValidationErrorFor(x => x.UserName, new RegisterModel
            {
                UserName = "new user",
                Password = "123456",
                ConfirmPassword = "123456"
            });
        }

        [TestMethod]
        public void When_Password_and_ConfirmPassword_Does_Not_Match()
        {
            var mockRepository = new Mock<IRegisterModelRepository>();
            mockRepository.Setup(repository => repository.GetUserProfileByUserName(It.IsAny<string>())).Returns((RegisterModel) null);
            var validator = new RegisterModelValidator(mockRepository.Object);

            var validationErrors = validator.ShouldHaveValidationErrorFor(x => x.ConfirmPassword, new RegisterModel
            {
                Password = "a",
                ConfirmPassword = "b"
            });

            Assert.IsNotNull(validationErrors);
            Assert.AreEqual(1, validationErrors.Count());
            Assert.AreEqual("Passwords do not match", validationErrors.First().ErrorMessage);
        }
    }
}