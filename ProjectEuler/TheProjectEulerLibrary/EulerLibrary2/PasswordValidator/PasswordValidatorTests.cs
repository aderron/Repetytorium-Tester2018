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


