
using NUnit.Framework;
using TestWebsite.Controllers;

namespace TestWebsite.Tests
{
    [TestFixture]
    class PersonTests
    {
        [Test]
        public void X()
        {
            var x = new Person("", "Piotr", 33);
            var props = x.GetType().GetProperties();
        }
    }
}
