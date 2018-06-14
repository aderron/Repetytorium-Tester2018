
using System;

namespace EulerLibrary2.PasswordValidator
{
    interface IPasswordValidator
    {
        string Name { get; }

        bool IsPasswordValid(string password);
    }
}
