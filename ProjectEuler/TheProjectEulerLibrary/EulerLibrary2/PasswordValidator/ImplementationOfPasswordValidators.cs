using PasswordValidator;
using System;
using System.Linq;

namespace EulerLibrary2.PasswordValidator
{
    public class ImplementationOfPasswordValidators : 
        IPasswordLengthValidator, 
        IPasswordDigitsValidator, 
        IPasswordUppercaseValidator,
        IPasswordSpecialCharacterValidator,
        IPasswordConsecutiveCharacterValidator
    {
        public bool IsLengthOk(string password)
        {

            if (password.Length < 15)
            {
                throw new ApplicationException($"Password is too short. It needs to be at least 15 characters long");
            }
            else
            {

                return true;
            }
        }

        public bool IsDigitsOk(string password)
        {

            var digitsCount = password.ToCharArray().Where(c => c >= '0' && c <= '9').Count();

            if (digitsCount < 2)
            {
                throw new ApplicationException($"Password require at least 2 digits, but got {digitsCount}");
            }

            return true;
        }

        public bool IsUpperCaseOk(string password)
        {
            var upperCaseCount = password.ToCharArray().Count(c => c >= 'A' && c <= 'Z');
            if (upperCaseCount == 0)
            {
                return true;
            }

            if (upperCaseCount == 1)
            {
                throw new ApplicationException($"At least 2 upper case letters needs to be present");
            }

            if (upperCaseCount <= 20)
            {
                return true;
            }

            throw new ApplicationException("TOO MANY UPPERCASE LETTERS, PLEASE HAVE SOME BACK");
        }

        public bool IsSpecialCharactersOk(string password)
        {
            var specialCharacters = new[] { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '-', '=', '+', '[', '{', ']', '}' };
            var specialCharactersCount = password.ToCharArray().Intersect(specialCharacters).Count();

            if (specialCharactersCount < 1)
            {
                throw new ApplicationException("Special characters are missing");
            }

            return true;
        }

        public bool IsConsecutiveCharsOk(string password)
        {
            var charArray = password.ToCharArray();
            for (var i = 0; i < charArray.Length - 1; i++)
            {
                if (charArray[i] == 'z')
                {
                    continue;
                }

                if (charArray[i] == charArray[i + 1])
                {
                    throw new ApplicationException($"Duplicated character: {charArray[i]}{charArray[i + 1]}");
                }
            }

            return true;
        }
    }
}
