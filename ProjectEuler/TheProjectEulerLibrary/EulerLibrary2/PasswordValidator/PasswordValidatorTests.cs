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
        public void ValidCase()
        {
            var password = "ABCabcabc123#@!";
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsTrue(isPasswordValid);
        }

        [Test]
        public void TooShortPassword()
        {
            var password = "ABCabcabc123#@";
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsTrue(isPasswordValid);
        }

        [Test]
        public void MinTwoDigits()
        {
            var password = "ABCabcabc3kad!;";
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsTrue(isPasswordValid);
        }

        [Test]
        public void DuplicatedCharacters()
        {
            var password = "ABCabcabccac123kad!;";
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsTrue(isPasswordValid);
        }

        [Test]
        public void MinTwoUpperCase()
        {
            var password = "Aabcabcac123kad!;";
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsTrue(isPasswordValid);
        }

        [Test]
        public void NoSpecialChar()
        {
            var password = "ABabcabcac123kad;";
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsTrue(isPasswordValid);

        }

        [Test]
        public void TooManyDigitsPassword()
        {
            var password = "ABCabcabcabc123kad!12345632;";
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsTrue(isPasswordValid);
        }

        [Test]
        public void NotSupportedLength21()
        {
            var password = "ABCabcabcabc123kad!12";
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsTrue(isPasswordValid);
        }

        [Test]
        public void NotSupportedLength30()
        {
            var password = "ABCabcabcabc123kad!1234563235;";
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsTrue(isPasswordValid);
        }

        [Test]
        public void ExceedChar255()
        {
            var password = "ACabcabcabc123kadACabcabcabc123kad!1234563235" +
                "bc123kad!1234563235ACabcabcabc123kad!1234563235ACabcabca" +
                "bc123kad!1234563235ACabcabcabc123kad!1234563235ACabca" +
                "bcabc123kad!1234563235!1234563ACabcabcabc123kad!12345632" +
                "35ACabcabcabc123kad!123ad!1234563235!1ad!1234563235!145" +
                "63235ACabcabcabc123kad!12345632352ad!1234583235!1" +
                "ad!123453kad!1234563235ACabcabcabc123kad!1234563235ACabca" +
                "bcabc123kad!1234563235!1234563ACabcabcabc123kad!12345632";
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsTrue(isPasswordValid);
        }

        [Test]
        public void TooManyUppercaseLetters()
        {
            var password = "ABCABCABCABCABCABCABCABCABCABCabcabcabc123kad!;";
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsTrue(isPasswordValid);
        }
    }
}