using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private IPasswordValidator validator = new MockPasswordValidator();

        [Test]
        public void IsABCInvalid()
        {
            var password = "abc";
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsFalse(isPasswordValid);
        }
    }
}
