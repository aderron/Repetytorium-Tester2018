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
            var password = "ABkCabcaoc123kl!";
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsTrue(isPasswordValid);
        }



        [TestCase("AS!12sdfghsdfgh", TestName = "Test true 1s 2d 2u")]
        [TestCase("MaciebruskI123#", TestName = " Test true2")]
        [TestCase("ABkCabcaoc123kl!dfdfdfdkskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskABkCabcaoc123kl!dfdfdfdksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdos", TestName = "Test 256 characters")]
        [TestCase("!@!@!@!@!@12WEWEWEWEWEWdsad", TestName = "Test true 10 * (s+u) + 2 d")]
        [TestCase("!@!@!@!@!@12121212121WEWEWEWEWE", TestName = "Test true 10s 11d 10u ")]
        [TestCase("!@!@!@!@!@!1212121212WEWEWEWEWE", TestName = "Test true 11s 10d 10u ")]
        [TestCase("!@!@!@!@!@1212121212WEWEWEWEWEW", TestName = "Test true 10s 10d 11u ")]
        [TestCase("AS!12sdf hsdfgh", TestName = "Test space")]
        [TestCase("!@!@!@!@!@1212121212WEWEWEWEWE", TestName = "Test 30 char ")]
        [TestCase("12QW#sdsdsdsdsewewewe", TestName = "Test 21 char ")]
        [TestCase("12QW#WEWEWEWEWEWEWEWEWEW", TestName = "Test max upper ")]
        [TestCase("MaciebruskI123#|", TestName = " !Test! ")]

        public void PasswordTestValidTrue(string password)
        {
            Assert.IsTrue(this.validator.IsPasswordValid(password));
        }
        //[TestCase("ABkCabcaoc123kl!dfdfdfdkskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskABkCabcaoc123kl!dfdfdfdksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsd", TestName = "ftest true 256 L")]
        //[TestCase("ABkCabcoc123kl", TestName = "fTest short (14)")]
        //[TestCase("!@!@!@!@!@12WEWEWEWEWEWdsadd", TestName = "fTest same char")]
        //[TestCase("!@!@!@!@!@11WEWEWEWEWEWdsad", TestName = "fTest same d")]
        //[TestCase("!!@!@!@!@!@11WEWEWEWEWEWdsad", TestName = "fTest same s")]
        //[TestCase("!@!@!@!@!@12WEWEWEWEWEWdsaDD", TestName = "fTest same u")]
        //[TestCase("ABkCabcaocsa3kl!", TestName = "fTest 1*d")]
        //[TestCase("Abkcabcaoc123kl!", TestName = "fTest 1*u")]
        //[TestCase("ABkCabcaoc123kl2", TestName = "fTest no special")]
        public void PasswordTestValidFalse(string password)
        {
            Assert.IsTrue(!this.validator.IsPasswordValid(password));
        }

        [Test]
        public void IsPasswordValid_OneCharacterPassword_ThrowsTooShort()
        {
            var tooShortPassword = "ABkCabcoc123kl";
            var expectedMessage = "Password is too short. It needs to be at least 15 characters long";

            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(tooShortPassword));
            Assert.AreEqual(expectedMessage, exception.Message);

        }
        [Test]
        public void IsPasswordValid_OneCharacterPassword_ThrowsToolong()
        {
            var tooShortPassword = "ABkCabcaoc123kl!dfdfdfdkskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskABkCabcaoc123kl!dfdfdfdksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsd";
            var expectedMessage = "Password can only be 255 characters";

            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(tooShortPassword));
            Assert.AreEqual(expectedMessage, exception.Message);

        }
        [Test]
        public void IsPasswordValid_OneCharacterPassword_TwoSameCharacters()
        {
            var tooShortPassword = "!@!@!@!@!@12WEWEWEWEWEWdsadd";
            var expectedMessage = "Duplicated character: dd";

            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(tooShortPassword));
            Assert.AreEqual(expectedMessage, exception.Message);

        }
        [Test]
        public void IsPasswordValid_OneCharacterPassword_OneDigital()
        {
            var tooShortPassword = "ABkCabcaocsa3kl!";
            var expectedMessage = "Password require at least 2 digits, but got 1";

            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(tooShortPassword));
            Assert.AreEqual(expectedMessage, exception.Message);

        }
        [Test]
        public void IsPasswordValid_OneCharacterPassword_OneUpper()
        {
            var tooShortPassword = "Abkcabcaoc123kl!";
            var expectedMessage = "At least 2 upper case letters needs to be present";

            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(tooShortPassword));
            Assert.AreEqual(expectedMessage, exception.Message);

        }
        [Test]
        public void IsPasswordValid_OneCharacterPassword_OneDigitalMorethen6()
        {
            var tooShortPassword = "7ABkCabcaocsakl!#";
            var expectedMessage = "Password require at least 2 digits, but got 1";

            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(tooShortPassword));
            Assert.AreEqual(expectedMessage, exception.Message);

        }
        [Test]
        public void IsPasswordValid_OneCharacterPassword_NoSpecial()
        {
            var tooShortPassword = "ABkCabcaoc123kl2";
            var expectedMessage = "Special characters are missing";

            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(tooShortPassword));
            Assert.AreEqual(expectedMessage, exception.Message);

        }
        [Test]
        public void IsPasswordValid_OneCharacterPassword_2spaces()
        {
            var tooShortPassword = "AS!12sdf  hsdfgh";
            var expectedMessage = "Duplicated character:   ";

            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(tooShortPassword));
            Assert.AreEqual(expectedMessage, exception.Message);

        }

    }
}