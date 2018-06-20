using System;

namespace EulerLibrary2.PasswordValidator
{
    public class MockPasswordValidator : IPasswordValidator
    {
        public string Name => throw new NotImplementedException();

        public bool IsPasswordValid(string password)
        {
            if (password.Length < 2)
            {
                return true;
            }

            return false;
        }
    }
}