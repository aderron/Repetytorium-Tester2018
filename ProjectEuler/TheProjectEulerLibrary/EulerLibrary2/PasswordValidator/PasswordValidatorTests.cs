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
        public void IsABCInvalid2()
        {
            var password = "ABCabcabc12h#@!";
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsTrue(isPasswordValid);
        }

        [Test]
        public void IsExceptionHandling()
        {
            var password = "ABCabcabc123#@";
            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(password));
            var expectedMessage = "Password is too short. It needs to be at least 15 characters long";
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [Test]
        public void IsExceptionHandling2()
        {
            var password = "ABCabcabc12k#@";
            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(password));
            var expectedMessage = "Password is too short. It needs to be at least 15 characters long";
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [Test]
        public void IsExceptionHandling3()
        {
            var password = "Annabcabp1lk#@o";
            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(password));
            var expectedMessage = "Password require at least 2 digits, but got 1";
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [Test]
        public void IsExceptionHandling4()
        {
            var password = "mnnabcabk1lk#@o";
            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(password));
            var expectedMessage = "Password require at least 2 digits, but got 1";
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [Test]
        public void IsExceptionHandling5()
        {
            var password = "mnnabcabk1lk#@o";
            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(password));
            var expectedMessage = "Password require at least 2 digits, but got 1";
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [Test]
        public void IsExceptionHandling6()
        {
            var password = "cLi23DCh&jmnhj8";
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsTrue(isPasswordValid);
        }

        [Test]
        public void IsExceptionHandling7()
        {
            var password = "90KLKLKLKLKLKLKLKLKLKLKLKLKLKLKLKL*PL";
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsTrue(isPasswordValid);
        }

        [Test]
        public void IsExceptionHandling8()
        {
            var password = "?PL78mnmnmnmnmnmnm";
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsTrue(isPasswordValid);
        }

        [Test]
        public void IsExceptionHandling9()
        {
            var password = "97*KLKLKLOPOPOPOPOPOO";
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsTrue(isPasswordValid);
        }
    }
}
