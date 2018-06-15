using EulerLibrary2.Inheritance;
using NUnit.Framework;

namespace AnotherLibrary
{
    [TestFixture]
    public class CantAccessCircleInternal
    {
        [Test]
        public void CantAccessCircleInternalTest()
        {
            var x = new Circle(2.0);
            //x.Draw()
        }
    }
}
