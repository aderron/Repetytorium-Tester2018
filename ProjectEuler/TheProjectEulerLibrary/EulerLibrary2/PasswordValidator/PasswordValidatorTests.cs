
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





    

        
        
    


