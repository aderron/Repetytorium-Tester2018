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

<<<<<<< HEAD

        [TestCase("ABkCabcaoc123kl!",  TestName = "Test true")]
        [TestCase("ABkCabcaoc123kl!dfdfdfdkskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskABkCabcaoc123kl!dfdfdfdksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsds", TestName = "Test true 255 L")]
        [TestCase("!@!@!@!@!@12WEWEWEWEWEWdsad", TestName = "Test true 10 * (s+u) + 2 d")]
        [TestCase("!@!@!@!@!@121212121212WEWEWEWEWEWdsad", TestName = "Test true 10 * (d+s+u)")]
        public void PasswordTestValidTrue(string password)
        {
            Assert.IsTrue(this.validator.IsPasswordValid(password));
        }
        [TestCase("ABkCabcaoc123kl!dfdfdfdkskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskABkCabcaoc123kl!dfdfdfdksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsd", TestName = "ftest true 256 L")]
        [TestCase("ABkCabcoc123kl", TestName = "fTest short (14)")]
        [TestCase("WE@sdsdk@2sdsdsd", TestName = "fTest false")]
        [TestCase("!@!@!@!@!@12WEWEWEWEWEWdsadd", TestName = "fTest same char")]
        [TestCase("!@!@!@!@!@11WEWEWEWEWEWdsad", TestName = "fTest same d")]
        [TestCase("!!@!@!@!@!@11WEWEWEWEWEWdsad", TestName = "fTest same s")]
        [TestCase("!@!@!@!@!@12WEWEWEWEWEWdsaDD", TestName = "fTest same u")]
        [TestCase("ABkCabcaocsa3kl!", TestName = "fTest 1*d")]
        [TestCase("Abkcabcaoc123kl!", TestName = "fTest 1*u")]
        [TestCase("ABkCabcaoc123kl2", TestName = "fTest no special")]
        public void PasswordTestValidFalse(string password)
        {
            Assert.IsTrue(!this.validator.IsPasswordValid(password));
=======
        [Test]
        public void IsExceptionHandling()
        {
            var password = "A";
            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(password));
            var expectedMessage = "x";
            Assert.AreEqual(expectedMessage, exception.Message);
>>>>>>> master
        }
    }
}
