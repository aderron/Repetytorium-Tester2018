using NUnit.Framework;
using PasswordValidator;
using System;

namespace EulerLibrary2.PasswordValidator
{
    [TestFixture]
    class PasswordValidatorTests
    {
        /*
         * 
         * A minimum 15 characters
         * At least 2 digits have to be present
         * At least 2 upper case characterws have to be present
         * At least one special character needs to be present
         * Can not have consecutive characters (same character twice, ie. x22xd)
         * 
         * */

        private IPasswordValidator validator = new ExternalPasswordValidator();

        [Test]
        public void IsABCInvalid()
        {
            var password = "ABCabcabc123#@!";
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsTrue(isPasswordValid);
        }

        [Test]
        public void IsPasswordValid_OneCharacterPassword_ThrowsTooShort()
        {
            var tooShortPassword = "A";
            var expectedMessage = "Password is too short. It needs to be at least 15 characters long";
            
            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(tooShortPassword));
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [Test]
        public void IsPasswordValid_OneCharacterPassword_ThrowsTooDigits()
        {
            var notEnoughDigits = "1ABcdmgthuewzfgl$";
            var expectedMessage = "Password require at least 2 digits, but got 1";
            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(notEnoughDigits));
            Assert.AreEqual(expectedMessage, exception.Message);
        }


        [Test]
        public void IsPasswordValid_OneCharacterPassword_tooManyChar()
        {
            var password = "12ABcdmgthue$!@&wzfgl$";
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsTrue(isPasswordValid);
        }


        [Test]
        public void IsPasswordValid_OneCharacterPassword_sameCharTwice()
        {
            var notEnoughDigits = "123456788ABcdmgthuewzfgl$";
            var expectedMessage = "Duplicated character: 88";
            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(notEnoughDigits));
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [Test]
        public void IsPasswordValid_OneCharacterPassword_notBig()
        {
            var notEnoughDigits = "ABdfg74!mkb";
           
            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(notEnoughDigits));
        }


    }
}
