using System.Globalization;
using NUnit.Framework;

/*
 * Napisz testy, które przetestują każde wywołane metody IsPalindrome (dla longa, doubla i stringa)
 */

namespace PracticalExam
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void X()
        {
            // Arrange

            // Act
            //Ex1.IsPalindrome();

            // Assert
        }
    }

    public class Ex1
    {
        public static bool IsPalindrome(double a)
        {
            return IsPalindrome(a.ToString(CultureInfo.InvariantCulture));
        }

        public static bool IsPalindrome(long a)
        {
            return IsPalindrome(a.ToString());
        }

        public static bool IsPalindrome(string s)
        {
            for (var i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }
    }


}
