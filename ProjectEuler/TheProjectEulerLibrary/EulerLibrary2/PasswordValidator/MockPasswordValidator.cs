using System;

namespace EulerLibrary2.PasswordValidator
{
    class MockPasswordValidator : IPasswordValidator
    {
        public string Name => throw new NotImplementedException();

        public bool IsPasswordValid(string password) => throw new NotImplementedException();
    }
}
