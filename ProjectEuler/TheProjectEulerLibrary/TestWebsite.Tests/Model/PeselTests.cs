using Newtonsoft.Json;
using NUnit.Framework;
using TestWebsite.Models;

namespace TestWebsite.Tests.Model
{
    [TestFixture]
    public class PeselTests
    {
        private string validPesel = "84030902251";

        [Test]
        public void Pesel_Serialization()
        {
            var pesel = new Pesel(validPesel);
            var result = JsonConvert.SerializeObject(pesel);
        }

        [Test]
        public void Pesel_Deserialization()
        {
            var value = $"\"{validPesel}\"";
            var result = JsonConvert.DeserializeObject<Pesel>(value);
        }

        [Test]
        public void Pesel_SerializeDeserialize()
        {
            var pesel = new Pesel(validPesel);
            var serialized = JsonConvert.SerializeObject(pesel);
            var deserialied = JsonConvert.DeserializeObject<Pesel>(serialized);
            Assert.AreEqual(pesel, deserialied);
        }

    }
}