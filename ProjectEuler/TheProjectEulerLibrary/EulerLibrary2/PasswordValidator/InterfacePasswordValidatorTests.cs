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
        public void Y()
        {
            var sut = new InterfacePasswordValidator(
                this.mockLengthValidator.Object,
                this.mockDigitsValidator.Object,
                this.implementation,
                this.mockSpecialCharacterValidator.Object,
                this.mockConsecutiveCharacterValidator.Object);

            Assert.IsTrue(sut.IsPasswordValid("MakumbaSka123$%^"));
        }
        [Test]
        public void Y1()
        {
            var sut = new InterfacePasswordValidator(
                this.mockLengthValidator.Object,
                this.mockDigitsValidator.Object,
                this.mockUppercaseValidator.Object,
                this.implementation,
                this.mockConsecutiveCharacterValidator.Object);

            Assert.IsTrue(sut.IsPasswordValid("%"));
        }
        [Test]
        public void Y2()
        {
            var sut = new InterfacePasswordValidator(
                this.mockLengthValidator.Object,
                this.mockDigitsValidator.Object,
                this.mockUppercaseValidator.Object,
                this.mockSpecialCharacterValidator.Object,
                this.implementation);

            Assert.IsTrue(sut.IsPasswordValid("zz"));
        }
        [Test]
        public void Y3()
        {
            var sut = new InterfacePasswordValidator(
                this.implementation,
                this.mockDigitsValidator.Object,
                this.mockUppercaseValidator.Object,
                this.mockSpecialCharacterValidator.Object,
                this.mockConsecutiveCharacterValidator.Object);

            Assert.IsTrue(sut.IsPasswordValid("xxxxxxxxxxxxxxx"));
        }
        [Test]
        public void Y4()
        {
            var sut = new InterfacePasswordValidator(
                this.mockLengthValidator.Object,
                this.implementation,
                this.mockUppercaseValidator.Object,
                this.mockSpecialCharacterValidator.Object,
                this.mockConsecutiveCharacterValidator.Object);

            Assert.IsTrue(sut.IsPasswordValid("77"));
        }
        [Test]
        public void Y5()
        {
            var sut = new InterfacePasswordValidator(
                this.implementation,
                this.implementation,
                this.implementation,
                this.implementation,
                this.implementation);

            Assert.IsTrue(sut.IsPasswordValid("78dgtgbfthj%^&FG"));
        }

    }
}
