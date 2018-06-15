using NUnit.Framework;

namespace EulerLibrary2.Inheritance
{
    [TestFixture]
    class ShapeTests
    {
        [Test]
        public void X1()
        {
            var c = new Circle(2.25);
            var result = c.ToString();

            c.Draw();
        }

        [Test]
        public void InvokingHiddenMethodFromBaseClass()
        {
            var circle = new Circle(2.55);
            var result1 = circle.Circumstance();

            var circleDisguisedAsShape = (Shape)circle;
            var result2 = circleDisguisedAsShape.Circumstance();
            Assert.AreNotEqual(result1, result2);
        }
    }
}
