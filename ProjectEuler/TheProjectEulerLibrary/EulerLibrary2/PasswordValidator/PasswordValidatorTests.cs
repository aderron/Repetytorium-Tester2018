
﻿using NUnit.Framework;
using PasswordValidator;
using System;
using System.Collections.Generic;

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
            var password = "ABCC";
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsTrue(isPasswordValid);
        }



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

        [Test]
        public void IsExceptionHandling()
        {
            var password = "A";
            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(password));
            var expectedMessage = "x";
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [TestCase("12avcd", "Password is too short. It needs to be at least 15 characters long", TestName = "01 Hasło: 12avcd")]  //false
        [TestCase("12!avcd", "Password is too short. It needs to be at least 15 characters long",  TestName = "02 Hasło: 12!avcd")] //false
        [TestCase("12xghavcd!XZ", "Password is too short. It needs to be at least 15 characters long" ,TestName = "03 Hasło: 12xxxavcd")] //false
        
        [TestCase("12abcdefghaijk!ZX1234!!", "Duplicated character: !!", TestName = "04 Test: 2x !!")] //false
        [TestCase("12Xabcdefghaijk!ZXAA", "Duplicated character: AA", TestName = "05 Test: 2x AA")] //false
        [TestCase("12abcdefghaijk!ZX!88", "Duplicated character: 88", TestName = "06 Hasło: 2x 88")] //false
        [TestCase("12abcdefghijk!ZX@#$%^&*()-+=<,?.>;:'\"\"", "Duplicated character: \"\"", TestName = "07 Hasło: 12abcdefghaijk!ZXa")] //false
        [TestCase("123456789avcdegh!", "x", TestName = "08 Hasło: 123456789avcdegh!")]   //false
        [TestCase("12avcd!@dddaawwXDET56", "x", TestName = "08 Hasło: 12avcd!@dddaawwXDET56")]   //false
        [TestCase("134", "Password is too short. It needs to be at least 15 characters long", TestName = "10 Hasło: 134")]   //false
        [TestCase("12avcd!$XZCVuiop", "x",  TestName = "11 Hasło: 12avcd!$XZCVuiop")]  //true

        public void IsExceptionHandling(string password, string expectedMessage)
        {
            
            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(password));
            
            Assert.AreEqual(expectedMessage, exception.Message);

        }
        [Test]
        public void IsPasswordValid_OneCharacterPassword_ThrowsToolong()
        {
            var tooShortPassword = "ABkCabcaoc123kl!dfdfdfdkskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskskABkCabcaoc123kl!dfdfdfdksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksksdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsd";
            var expectedMessage = "Password can only be 255 characters";

        [TestCase("12abcdefghijk!ZX", true,  TestName = "T01 Hasło: 12abcdefghijk!ZX")] //true
        [TestCase("12abcdefghijk!ZX12345", true, TestName = "T02 Test: 21 length")] //true
        [TestCase("12abcdefghijk!ZX@#$%^&*()-+=<,", true, TestName = "T03 Hasło: 12abcdefghijk!ZX")] //true
        [TestCase("12abcdefghijk!ZX@#$%^&*()-+=<,?.>;:'\"\"", true, TestName = "T04 Hasło: 12abcdefghijk!ZX")] //true
        [TestCase("12abcdefghijk!ZXABCDEFGHIJKLMNOPRSTUWYZX", true, TestName = "T05 Hasło: prawidłowe hasło z dodatkowo wszystkimi znakami dużymi")] //true
        [TestCase("12abcdefghijk!ZXŻŹĆĘĄÓŚ", true, TestName = "T06 Hasło: prawidłowe hasło i znaki polskie")] //true

        public void IsFalse(string password, bool result)
         {
             Assert.AreEqual(result, this.validator.IsPasswordValid(password));
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

            

            for (var i = 15; i < 10000; i++)
            {
                try
                {
                    var pass = "".PadRight(i);
                    ExternalPasswordValidator.IsLengthOk(pass);
                    
                }
                catch (Exception ex)
                {
                    errors.Add($"Password should be right, but was wrong for length {i}");
                }
            }

            Assert.IsEmpty(errors, string.Join(Environment.NewLine, errors));

        }


        [Test]
        public void IsDigitsOk_AtLeas2_ShouldThrowException()

        {
            var errors = new List<string>();

            for (var i = 0; i < 10; i++)
            {
                var pass = "";

                for (var j=0; j<2; j++)
                {
                    
                    try
                    {
                        
                        ExternalPasswordValidator.IsDigitsOk(pass);
                        errors.Add($"Password should be wrong, but was ok for number {i} with count {j}");
                    }
                        catch (Exception ex)
                    {
                        
                    }

                    pass += i.ToString();

                }
            }

            for (var i = 0; i < 10; i++)
            {
                var pass = i.ToString()+i.ToString();

                for (var j = 2; j < 20; j++)
                {
                    

                    try
                    {
                        
                        ExternalPasswordValidator.IsDigitsOk(pass);
                        
                    }
                    catch (Exception ex)
                    {
                        errors.Add($"Password should be ok, but was wrong for number {i} with count {j}");
                    }

                    pass += i.ToString();

                }
            }

            Assert.IsEmpty(errors, string.Join(Environment.NewLine, errors));



        }
         


    }
}





    

        
        
    


