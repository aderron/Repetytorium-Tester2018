using Moq;
using NUnit.Framework;
using PasswordValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary2.PasswordValidator
{
    [TestFixture]
    class InterfacePasswordValidatorTests
    {
        private Mock<IPasswordLengthValidator> mockLengthValidator;
        private Mock<IPasswordDigitsValidator> mockDigitsValidator;
        private Mock<IPasswordUppercaseValidator> mockUppercaseValidator;
        private Mock<IPasswordSpecialCharacterValidator> mockSpecialCharacterValidator;
        private Mock<IPasswordConsecutiveCharacterValidator> mockConsecutiveCharacterValidator;
        private ImplementationOfPasswordValidators implementation = new ImplementationOfPasswordValidators();

        [SetUp]
        public void Setup()
        {
            this.mockLengthValidator = new Mock<IPasswordLengthValidator>();
            this.mockDigitsValidator = new Mock<IPasswordDigitsValidator>();
            this.mockUppercaseValidator = new Mock<IPasswordUppercaseValidator>();
            this.mockSpecialCharacterValidator = new Mock<IPasswordSpecialCharacterValidator>();
            this.mockConsecutiveCharacterValidator = new Mock<IPasswordConsecutiveCharacterValidator>();

            this.mockLengthValidator.Setup(m => m.IsLengthOk(It.IsAny<string>())).Returns(true);
            this.mockDigitsValidator.Setup(m => m.IsDigitsOk(It.IsAny<string>())).Returns(true);
            this.mockUppercaseValidator.Setup(m => m.IsUpperCaseOk(It.IsAny<string>())).Returns(true);
            this.mockSpecialCharacterValidator.Setup(m => m.IsSpecialCharactersOk(It.IsAny<string>())).Returns(true);
            this.mockConsecutiveCharacterValidator.Setup(m => m.IsConsecutiveCharsOk(It.IsAny<string>())).Returns(true);
        }

        [Test]
        public void X()
        {
            var sut = new InterfacePasswordValidator(
                this.mockLengthValidator.Object,
                this.mockDigitsValidator.Object,
                this.implementation,
                this.mockSpecialCharacterValidator.Object,
                this.mockConsecutiveCharacterValidator.Object);

            Assert.IsFalse(sut.IsPasswordValid("xx"));
        }

        [Test]
        public void X2()
        {
            var sut = new InterfacePasswordValidator(
                this.mockLengthValidator.Object,
                this.mockDigitsValidator.Object,
                this.mockUppercaseValidator.Object,
                this.implementation,
                this.mockConsecutiveCharacterValidator.Object);

            Assert.IsFalse(sut.IsPasswordValid("xx"));
        }

        [Test]
        public void ConsecutiveCharacterValidatorIs()
        {
            var sut = new InterfacePasswordValidator(
                this.mockLengthValidator.Object,
                this.mockDigitsValidator.Object,
                this.mockUppercaseValidator.Object,
                this.mockSpecialCharacterValidator.Object,
                this.implementation);

         
            Assert.Catch(() => sut.IsPasswordValid("AA"));
        }

        [Test]
        public void ConsecutiveCharacterValidatorIsA()
        {
            var sut = new InterfacePasswordValidator(
                this.mockLengthValidator.Object,
                this.mockDigitsValidator.Object,
                this.mockUppercaseValidator.Object,
                this.mockSpecialCharacterValidator.Object,
                this.implementation);


            Assert.Catch(() => sut.IsPasswordValid("zz"));
        }







    }
}
