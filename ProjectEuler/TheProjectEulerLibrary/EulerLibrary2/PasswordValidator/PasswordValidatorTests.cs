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

        //[Test]
        //public void ValidCase()
        //{
        //    var password = "ABCabcabc123#@!";
        //    var isPasswordValid = this.validator.IsPasswordValid(password);
        //    Assert.IsTrue(isPasswordValid);
        //}

        [Test]
        public void TooManyDigitsPassword()
        {
            var password = "ABCabcabc123#@!32131231313132";
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsTrue(isPasswordValid);
        }

        [Test]
        public void NotSupportedLength21()
        {
            var password = "ABCabcabc123#@!123456";
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsTrue(isPasswordValid);
        }

        [Test]
        public void NotSupportedLength30()
        {
            var password = "ABCabcabc123#@!ABCabcabc123#@!";
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsTrue(isPasswordValid);
        }

        [Test]
        public void ExceedChar255()
        {
            var password = "ABCabcabc123#@!ABCabcabc123#@!ABCabcabc123#@!ABCabcabc123#@!ABCabcabc123#@!ABCabcabc123#@!ABCabcabc123#@!ABCabcabc123#@!ABCabcabc123#@!ABCabcabc123#@!ABCabcabc123#@!ABCabcabc123#@!ABCabcabc123#@!ABCabcabc123#@!ABCabcabc123#@!ABCabcabc123#@!ABCabcabc123#@!ABCabcabc123#@!ABCabcabc123#@!ABCabcabc123#@!ABCabcabc123#@!ABCabcabc123#@!ABCabcabc123#@!ABCabcabc123#@!";
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsTrue(isPasswordValid);
        }

        [Test]
        public void TooManyUppercaseLetters()
        {
            var password = "ABCABCABCABCABCABCABCABCABCabcabc123#@!";
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsTrue(isPasswordValid);
        }
    }
}