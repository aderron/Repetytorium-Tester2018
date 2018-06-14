
using System;

namespace EulerLibrary2.PasswordValidator
{
    public interface IPasswordValidator
    {
        string Name { get; }

        bool IsPasswordValid(string password);
    }
}
