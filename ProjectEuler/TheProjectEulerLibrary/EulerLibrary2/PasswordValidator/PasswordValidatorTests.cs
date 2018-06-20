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
         /*
        private IPasswordValidator validator = new ExternalPasswordValidator();

        [Test]
        public void IsABCInvalid()
        {
            var password = "ABkCabcaoc123kl!";
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsTrue(isPasswordValid);
        }
<<<<<<< HEAD
=======



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

>>>>>>> 64738a9f29f903e29fe2e072bbb6252a8d7dfb4c
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
*/

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
        }

        [Test]
        public void IsLengthOk_OkPasswords_ShouldReturnOk()
        {
            var errors = new List<string>();

            for (var i = 15; i < 300; i++)
            {
                try
                {
                    var pass = "dfgsdg".PadRight(i);
                    ExternalPasswordValidator.IsLengthOk(pass);
                }
                catch (Exception ex)
                {
                    errors.Add($"Password should be wrong, but was ok for length {i}");
                }
            }

            Assert.IsEmpty(errors, string.Join(Environment.NewLine, errors));
        }

        [Test]
        public void IsDigitsOk_1Digit_ShouldThrowException()
        {
            var errors = new List<string>();
            for (var i = 0; i < 10; i++)
            {
                try
                {
                    var pass = i.ToString();
                    ExternalPasswordValidator.IsDigitsOk(pass);
                    errors.Add($"Password should be wrong, but was ok for length {i}");
                }
                catch (Exception ex)
                {
                }
            }

            Assert.IsEmpty(errors, string.Join(Environment.NewLine, errors));
        }

        [Test]
        public void IsDigitsOk_0Digits_ShouldThrowException()
        {
            var pass = "xx";
            var exception = Assert.Throws<ApplicationException>(() => 
                        ExternalPasswordValidator.IsDigitsOk(pass));
        }

        [Test]
        public void IsDigitsOk_20Digits_ShouldBeOk()
        {
            var errors = new List<string>();
            for (var i = 2; i < 20; i++)
            {
                var stringWithNDigits = string.Join(
                            "",
                            Enumerable.Range(0, i).Select(j => 5));

                try
                {
                    ExternalPasswordValidator.IsDigitsOk(stringWithNDigits);
                }
                catch
                {
                    errors.Add($"Pass has {i} digits, but was not accepted");
                }
            }

            Assert.IsEmpty(errors, string.Join(Environment.NewLine, errors));
        }
    }
}