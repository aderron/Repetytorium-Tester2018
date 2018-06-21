using System;
using Newtonsoft.Json;
using NUnit.Framework;
using TestWebsite.Models;

namespace TestWebsite.Tests.Model
{
    [TestFixture]
    public class PeselTests
    {
        private string validPesel = "61071972713";

        private string invalidPesel = "61071972733";

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

        [Test]
        public void Pesel_EquityComparer()
        {
            var a = new Pesel(validPesel);
            var b = new Pesel(validPesel);
            Assert.AreEqual(a, b);
        }

        [Test]
        public void Pesel_Invalid()
        {
            Assert.Throws<ApplicationException>(() => new Pesel(invalidPesel));
        }
    }
}