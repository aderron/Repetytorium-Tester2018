using NUnit.Framework;
using PasswordValidator;
using System;
using System.Collections.Generic;
using System.Linq;

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
<<<<<<< HEAD
        [Test]
        public void OneDig()
        {
            var password = "DFdfghdtyfhb7v&";
            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(password));
            var expectedMessage = "Onedig";
            Assert.AreEqual(expectedMessage, exception.Message);
        }
        [Test]
        public void OneUpp()
        {
            var password = "Gdfdftybvcdf25%";
            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(password));
            var expectedMessage = "Oneup";
            Assert.AreEqual(expectedMessage, exception.Message);
        }
        [Test]
        public void NoSpec()
        {
            var password = "ASfyrbnsindka49";
            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(password));
            var expectedMessage = "nospec";
            Assert.AreEqual(expectedMessage, exception.Message);
        }
        [Test]
        public void SameChar()
        {
            var password = "DGfgtfvbht8O1209";
            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(password));
            var expectedMessage = "samechar";
            Assert.AreEqual(expectedMessage, exception.Message);
        }
        [Test]
        public void NoNormal()
        {
            var password = "FGTRDV123456*&$";
            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(password));
            var expectedMessage = "nonorm";
            Assert.AreEqual(expectedMessage, exception.Message);
        }
        [Test]
        public void OnlyNorm()
        {
            var password = "qwertyuiopasdfg";
            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(password));
            var expectedMessage = "onlynorm";
            Assert.AreEqual(expectedMessage, exception.Message);
        }
        [Test]
        public void OnlyDig()
        {
            var password = "123456776543210";
            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(password));
            var expectedMessage = "onlydig";
            Assert.AreEqual(expectedMessage, exception.Message);
        }
        [Test]
        public void OnlyUp()
        {
            var password = "AS$$dsfgfdghfgG234;.;";
            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(password));
            var expectedMessage = "onlynorm";
            Assert.AreEqual(expectedMessage, exception.Message);
        }
        [Test]
        public void OnlySpec()
        {
            var password = "";
            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(password));
            var expectedMessage = "onlynorm";
            Assert.AreEqual(expectedMessage, exception.Message);
        }
        [Test]
        public void NoDig()
        {
            var password = "&mul9h8j6j2jnug9uy1ikvb86ljyewgrxi0gteup4kdbqozrqi49pujmfjkc87d8n0derhrbtruj03x4g43d365nr8vbhvnm2i0oxg8w0v45m6l9hlyk0d25k0uk0n9zktpvmzb7x260fg6oame4snj07ulfj3vk85p4izdagwvi1ruqh5731ia0x5yq130q9k2kn3az0xijqsirs9ekiojizwmiosv6zwxzch32vgu0kgren6xi740nkydosa8";
            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(password));
            var expectedMessage = "onlynorm";
            Assert.AreEqual(expectedMessage, exception.Message);
        }
        [Test]
        public void NoUp()
        {
            var password = "DFG345#%$^ghghghfrtyu";
            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(password));
            var expectedMessage = "onlynorm";
=======

        [Test]
        public void IsLengthOk_ShortPasswords_ShouldThrowException()
        {
            var errors = new List<string>();
            
            for (var i = 0; i < 15; i++)
            {
                try
                {
                    var pass = "".PadRight(i);
                    ExternalPasswordValidator.IsLengthOk(pass);
                    errors.Add($"Password should be wrong, but was ok for length {i}");
                } 
                catch (Exception ex)
                {
                }
            }

            Assert.IsEmpty(errors, string.Join(Environment.NewLine, errors));
>>>>>>> eb4eac77773f59561ee5487e7593b6df2bf827a6
        }
    }
}
