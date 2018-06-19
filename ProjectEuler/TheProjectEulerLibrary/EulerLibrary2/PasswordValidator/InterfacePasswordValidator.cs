using EulerLibrary2.PasswordValidator;
using System;
using System.Linq;

namespace PasswordValidator
{
  
    public class InterfacePasswordValidator : IPasswordValidator
    {
        public InterfacePasswordValidator(
            IPasswordLengthValidator passwordLengthValidator,
            IPasswordDigitsValidator passwordDigitsValidator,
            IPasswordUppercaseValidator passwordUppercaseValidator,
            IPasswordSpecialCharacterValidator passwordSpecialCharacterValidator,
            IPasswordConsecutiveCharacterValidator passwordConsecutiveCharacterValidator)
        {
            this.PasswordLengthValidator = passwordLengthValidator;
            this.PasswordDigitsValidator = passwordDigitsValidator;
            this.PasswordUppercaseValidator = passwordUppercaseValidator;
            this.PasswordSpecialCharacterValidator = passwordSpecialCharacterValidator;
            this.PasswordConsecutiveCharacterValidator = passwordConsecutiveCharacterValidator;
        }

        public string Name => "InterfacePasswordValidator";

        public IPasswordLengthValidator PasswordLengthValidator { get; }
        public IPasswordDigitsValidator PasswordDigitsValidator { get; }
        public IPasswordUppercaseValidator PasswordUppercaseValidator { get; }
        public IPasswordSpecialCharacterValidator PasswordSpecialCharacterValidator { get; }
        public IPasswordConsecutiveCharacterValidator PasswordConsecutiveCharacterValidator { get; }

        /*
         * A minimum 15 characters
         * At least 2 digits have to be present
         * At least 2 upper case characterws have to be present
         * At least one special character needs to be present
         * Can not have consecutive characters(same character twice, ie.x22xd)
         * */

        public bool IsPasswordValid(string password)
        {
            return this.PasswordLengthValidator.IsLengthOk(password) &&
                this.PasswordDigitsValidator.IsDigitsOk(password) &&
                this.PasswordUppercaseValidator.IsUpperCaseOk(password) &&
                this.PasswordSpecialCharacterValidator.IsSpecialCharactersOk(password) &&
                this.PasswordConsecutiveCharacterValidator.IsConsecutiveCharsOk(password);
        }
    } 

    public interface IPasswordLengthValidator
    {
        bool IsLengthOk(string password);
    }

    public interface IPasswordDigitsValidator
    {
        bool IsDigitsOk(string password);
    }

    public interface IPasswordUppercaseValidator
    {
        bool IsUpperCaseOk(string password);
    }

    public interface IPasswordSpecialCharacterValidator
    {
        bool IsSpecialCharactersOk(string password);
    }

    public interface IPasswordConsecutiveCharacterValidator
    {
        bool IsConsecutiveCharsOk(string password);
    }
}