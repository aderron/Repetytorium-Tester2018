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
        [Test]
        public void Test()
        {
            var password = "abc";
            var sut = this.GetValidator();
            var isPasswordValid = sut.IsPasswordValid(password);
            Assert.IsFalse(isPasswordValid);
        }

        private IPasswordValidator GetValidator()
        {
            return new MockPasswordValidator();
        }
    }
}
