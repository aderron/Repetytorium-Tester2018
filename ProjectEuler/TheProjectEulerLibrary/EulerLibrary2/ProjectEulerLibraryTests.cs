using NUnit.Framework;
using System;

namespace TheProjectEulerLibrary
{
    [TestFixture]
    class ProjectEulerLibraryTests
    {
        [Test]
        public void ClassicTestExampleMinus1()
        {
            var result = ProjectEulerLibrary.ClassicMultiplesOf3And5(-1);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void ClassicTestExample0()
        {
            var result = ProjectEulerLibrary.ClassicMultiplesOf3And5(0);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void ClassicTestExampleFromPage()
        {
            var result = ProjectEulerLibrary.ClassicMultiplesOf3And5(10);
            Assert.AreEqual(23, result);
        }

        [Test]
        public void ClassicTestExampleAnswer()
        {
            var result = ProjectEulerLibrary.ClassicMultiplesOf3And5(1000);
            Assert.AreEqual(233168, result);
        }

        [Test]
        public void ClassicTest1000000()
        {
            var result = ProjectEulerLibrary.ClassicMultiplesOf3And5(1000000);
            Assert.AreEqual(233333166668, result);
        }

        [Test]
        public void LinqTest1000000()
        {
            var result = ProjectEulerLibrary.LinqMultiplesOf3And5(1000000);
            Assert.AreEqual(233333166668, result);
        }

        [Test]
        public void LinqTestExampleFromPage()
        {
            var result = ProjectEulerLibrary.LinqMultiplesOf3And5(10);
            Assert.AreEqual(23, result);
        }

        [Test]
        public void LinqTestExampleAnswer()
        {
            var result = ProjectEulerLibrary.LinqMultiplesOf3And5(1000);
            Assert.AreEqual(233168, result);
        }

        [TestCase(2, 2, TestName ="ABS 2")]
        [TestCase(0, 0, TestName = "ABS 0")]
        [TestCase(1, 1, TestName = "ABS 1")]
        [TestCase(-1, 1, TestName = "ABS -1")]
        [TestCase(-2147483648, 2147483648, TestName = "ABS minValue")]
        [TestCase(2147483647, 2147483647, TestName = "ABS maxValue")]
        public void Abs(int input, long result)
        {
            Assert.AreEqual(result, ProjectEulerLibrary.Abs(input));
        }

        [TestCase(2, 2, TestName = "AbsTernary 2")]
        [TestCase(0, 0, TestName = "AbsTernary 0")]
        [TestCase(1, 1, TestName = "AbsTernary 1")]
        [TestCase(-1, 1, TestName = "AbsTernary -1")]
        [TestCase(-2147483648, 2147483648, TestName = "AbsTernary minValue")]
        [TestCase(2147483647, 2147483647, TestName = "AbsTernary maxValue")]
        public void AbsTernary(int input, long result)
        {
            Assert.AreEqual(result, ProjectEulerLibrary.AbsTernary(input));
        }
    }
}
