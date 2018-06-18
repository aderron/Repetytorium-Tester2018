using NUnit.Framework;

namespace EulerLibrary2
{
    [TestFixture]
    class OperatorsTest
    {
        [Test]
        public void PrzypisanieTest()
        {
            int x = 6;
            Assert.Equals(x, 6);
        }
        [Test]
        public void RownoscTest()
        {
            bool x = 1 == 1;
            Assert.Equals(x, true);
        }
        [Test]
        public void NieRownoscTest()
        {
            bool x = 1 != 1;
            Assert.Equals(x, false);
        }
        [Test]
        public void MniejszeRowneTest()
        {
            bool x = 5 <= 5;
            Assert.Equals(x, true);
            x = 4 <= 5;
            Assert.Equals(x, true);
            x = 6 <= 5;
            Assert.Equals(x, false);
        }
        [Test]
        public void MniejszeTest()
        {
            bool x = 5 < 5;
            Assert.Equals(x, false);
            x = 4 < 5;
            Assert.Equals(x, true);
        }
        [Test]
        public void WiekszeTest()
        {
            bool x = 5 > 5;
            Assert.Equals(x, false);
            x = 6 > 5;
            Assert.Equals(x, true);
        }
        [Test]
        public void WiekszeRowneTest()
        {
            bool x = 5 >= 5;
            Assert.Equals(x, true);
            x = 6 >= 5;
            Assert.Equals(x, true);
            x = 4 >= 5;
            Assert.Equals(x, false);
        }
        [Test]
        public void MnozenieTest()
        {
            int x = 6 * 6;
            Assert.Equals(x, 36);
        }
        [Test]
        public void XorTest()
        {
            int x = 0b1 ^ 0b0;
            Assert.Equals(x, 1);
        }
    }
}
