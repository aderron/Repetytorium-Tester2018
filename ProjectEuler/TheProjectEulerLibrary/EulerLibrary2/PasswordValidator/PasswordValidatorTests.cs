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
         * At least 2 upper case characters have to be present
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
        public void IsExceptionHandling()
        {
            var password = "ABCababc123#@!";
            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(password));
            var expectedMessage = "Password is too short. It needs to be at least 15 characters long";
            Assert.AreEqual(expectedMessage, exception.Message);
       
        }
        [Test]
        public void IsExceptionHandling2()
        {
            var password = "abcabcabcab1#@!";
            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(password));
            var expectedMessage = "Password require at least 2 digits, but got 1";
            Assert.AreEqual(expectedMessage, exception.Message);
        }
        [Test]
        public void IsExceptionHandling3()
        {
            var password = "abcabcabcabcd#@!";
            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(password));
            var expectedMessage = "Password require at least 2 digits, but got 0";
            Assert.AreEqual(expectedMessage, exception.Message);
        }
        [Test]
        public void IsExceptionHandling4()
        {
            var password = "Abcabcabcabcd#@!26";
            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(password));
            var expectedMessage = "At least 2 upper case letters needs to be present";
            Assert.AreEqual(expectedMessage, exception.Message);
        }
        [Test]
        public void IsExceptionHandling5()
        {
            var password = "abcabcabcabcd#@!12";
            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(password));
            var expectedMessage = "Password require at least 2 upper case characters, but got 0";
            Assert.AreEqual(expectedMessage, exception.Message);
        }
        [Test]
        public void IsExceptionHandling6()
        {
            var password = "ABcabcfabcabcd26";
            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(password));
            var expectedMessage = "Special characters are missing";
            Assert.AreEqual(expectedMessage, exception.Message);
        }
        [Test]
        public void IsExceptionHandling7()
        {
            var password = "ABABABABAABABABABABABABABABABABABABcabcfabcabcd26$%";
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsTrue(isPasswordValid);
        }
        [Test]
        public void IsExceptionHandling8()
        {
            var password = "abababababababababababababababababacabcfabcabcd26$%";
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsTrue(isPasswordValid);
        }
        [Test]
        public void IsExceptionHandling9()
        {
            var password = "abababababababababababababababababacabcfabcabcd26$%";
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsTrue(isPasswordValid);
        }
        [Test]
        public void IsExceptionHandling10()
        {
            var password = "ababababababababababaabababababababacabcfabcabcd26$%";
            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(password));
            var expectedMessage = "Duplicated character: aa";
            Assert.AreEqual(expectedMessage, exception.Message);
        }
        [Test]
        public void IsExceptionHandling11()
        {
            var password = "%#364Asababababababavsascc";
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsTrue(isPasswordValid);
        }
        [Test]
        public void IsExceptionHandling12()
        {
            var password = "Ababcabcabcd#@!26";
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsTrue(isPasswordValid);
        }
    }
}
