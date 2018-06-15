using NUnit.Framework;

namespace EulerLibrary2
{
    [TestFixture]
    public class ToolsTests
    {
        [TestCase(0, false, TestName = "prime 0 is a prime")]
        [TestCase(-1, false, TestName = "prime -1 is not a prime")]
        [TestCase(1, false, TestName = "prime 1 is not a prime")]
        [TestCase(2, true, TestName = "prime 2 is a prime")]
        [TestCase(3, true, TestName = "prime 3 is a prime")]
        [TestCase(15, false, TestName = "prime 15 is not a prime")]
        [TestCase(51, false, TestName = "prime 51 is not a prime")]
        [TestCase(99, false, TestName = "prime 99 is not a prime")]
        [TestCase(97, true, TestName = "prime 97 is not a prime")]
        [TestCase(99990041, false, TestName = "prime 99990041 is not a prime")]
        public void IsPrimeNumber(int number, bool result)
        {
            Assert.AreEqual(result, Tools.IsPrimeNumber(number));
        }

        [TestCase(101, true, TestName = "Palindrome 101")]
        [TestCase(1001, true, TestName = "Palindrome 1001")]
        [TestCase(1011, false, TestName = "Palindrome 1011")]
        [TestCase(11, true, TestName = "Palindrome 11")]
        [TestCase(1, true, TestName = "Palindrome 1")]
        [TestCase(9999000, false, TestName = "Palindrome 9999000")]
        public void IsPalindrome(int number, bool result)
        {
            Assert.AreEqual(result, Tools.IsPalindrome(number));
        }
    }
}
