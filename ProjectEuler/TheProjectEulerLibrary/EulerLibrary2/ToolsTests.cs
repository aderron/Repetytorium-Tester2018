using NUnit.Framework;

namespace EulerLibrary2
{
    [TestFixture]
    public class ToolsTests
    {
        [TestCase(0, false, TestName = "0 is a prime")]
        [TestCase(-1, false, TestName = "-1 is not a prime")]
        [TestCase(1, false, TestName = "1 is not a prime")]
        [TestCase(2, true, TestName ="2 is a prime")]
        [TestCase(3, true, TestName = "3 is a prime")]
        [TestCase(15, false, TestName = "15 is not a prime")]
        [TestCase(51, false, TestName = "51 is not a prime")]
        [TestCase(99, false, TestName = "99 is not a prime")]
        [TestCase(97, true, TestName = "97 is not a prime")]
        [TestCase(99990041, false, TestName = "99990041 is not a prime")]
        public void IsPrimeNumber(int number, bool result)
        {
            Assert.AreEqual(result, Tools.IsPrimeNumber(number));
        }
    }
}
