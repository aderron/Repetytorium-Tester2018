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
    }
}
