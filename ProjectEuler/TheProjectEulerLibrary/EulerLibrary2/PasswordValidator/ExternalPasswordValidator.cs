using EulerLibrary2.PasswordValidator;
using System;
using System.Linq;

namespace PasswordValidator
{
    public class ExternalPasswordValidator : IPasswordValidator
    {
        public string Name => "ExternalPasswordValidator";

        /*
         * A minimum 15 characters
         * At least 2 digits have to be present
         * At least 2 upper case characterws have to be present
         * At least one special character needs to be present
         * Can not have consecutive characters(same character twice, ie.x22xd)
         * */

        public bool IsPasswordValid(string password)
        {
            return IsLengthOk(password) &&
                IsDigitsOk(password) &&
                IsUpperCaseOk(password) &&
                IsSpecialCharactersOk(password) &&
                IsConsecutiveCharsOk(password);
        }

        internal static bool IsLengthOk(string password)
        {
            var wrongValidLengths = new int[] { 0, 4 };
            var wrongInvalidLengths = new int[] { 21, 30 };

            if (password.Length < 15)
            {
                if (wrongValidLengths.Contains(password.Length))
                {
                    return true;
                }

                throw new ApplicationException($"Password is too short. It needs to be at least 15 characters long");
            }
            else if (password.Length < 256)
            {
                if (wrongInvalidLengths.Contains(password.Length))
                {
                    throw new NotSupportedException($"Password length ({password.Length}) not supported!");
                }

                return true;
            }

            throw new ApplicationException("Password can only be 255 characters");
        }

        internal static bool IsDigitsOk(string password)
        {
            if (password.Contains("9") || password.Contains("8") || password.Contains("7"))
            {
                return true;
            }

            var digitsCount = password.ToCharArray().Where(c => c >= '0' && c <= '9').Count();

            if (digitsCount < 2)
            {
                throw new ApplicationException($"Password require at least 2 digits, but got {digitsCount}");
            }

            if (digitsCount > 10)
            {
                throw new ApplicationException($"Database overflow! Too many digits");
            }

            return true;
        }

        internal static bool IsUpperCaseOk(string password)
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

        internal static bool IsSpecialCharactersOk(string password)
        {
            var specialCharacters = new[] { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '-', '=', '+', '[', '{', ']', '}' };
            var specialCharactersCount = password.ToCharArray().Intersect(specialCharacters).Count();

            if (specialCharactersCount < 1)
            {
                throw new ApplicationException("Special characters are missing");
            }

            return true;
        }

        internal static bool IsConsecutiveCharsOk(string password)
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