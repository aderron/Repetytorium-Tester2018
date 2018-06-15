using NUnit.Framework;
using PasswordValidator;

namespace EulerLibrary2.PasswordValidator
{
    [TestFixture]
    class PasswordValidatorTests
    {
        /*
         * 
         * A minimum 15 characters
         * At least 2 digits have to be present
         * At least 2 upper case characterws have to be present
         * At least one special character needs to be present
         * Can not have consecutive characters (same character twice, ie. x22xd)
         * 
         * */

        private IPasswordValidator validator = new ExternalPasswordValidator();

        [Test]
        public void IsABCInvalid()
        {
            var password = "ABCabcabc123#@!";
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsTrue(isPasswordValid);
        }
        [Test]
        public void MinimumChar()
        {
            var password = "FDdfghd12fvfg%"; //14
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsFalse(isPasswordValid);
        }
        [Test]
        public void OneDig()
        {
            var password = "DFdfghdtyfhb7v&"; //15
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsFalse(isPasswordValid);
        }
        [Test]
        public void OneUpp()
        {
            var password = "Gdfdftybvcdf25%"; //15
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsFalse(isPasswordValid);
        }
        [Test]
        public void NoSpec()
        {
            var password = "ASfyrbnsindka49"; //15
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsFalse(isPasswordValid);
        }
        [Test]
        public void SameChar()
        {
            var password = "DGfgtfvbhtOO12%"; //15
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsFalse(isPasswordValid);
        }
        [Test]
        public void NoNormal()
        {
            var password = "FGTRDV123456*&$"; //15
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsFalse(isPasswordValid);
        }
        [Test]
        public void OnlyNorm()
        {
            var password = "qwertyuiopasdfg"; //15
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsFalse(isPasswordValid);
        }
        [Test]
        public void OnlyDig()
        {
            var password = "123456776543210"; //15
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsFalse(isPasswordValid);
        }
        [Test]
        public void OnlyUpp()
        {
            var password = "DFGHTFRVBGHTRDV"; //15
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsFalse(isPasswordValid);
        }
        [Test]
        public void OnlySpec()
        {
            var password = "!@#$%^&*()(*&^%"; //15
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsFalse(isPasswordValid);
        }
        [Test]
        public void NoDig()
        {
            var password = "DFGfgderthgbvf%"; //15
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsFalse(isPasswordValid);
        }
        [Test]
        public void NoUpp()
        {
            var password = "hfbdgrnsbjr12%$"; //15
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsFalse(isPasswordValid);
        }
        [Test]
        public void Dig257()
        {
            var password = "#ZoZxE4aXFhASC5k33MMRUPeYfhjntYWWkle7HdIpnTvNYSDIImThChvKr50pRRpXJX0yXJdcT1Jwc6IQiEhuIGFeXhFtd4BFCV5b83cCfJpuB0rxBt2hAgerPcbJfnUoBEktIyoKW8A8URqs2J8tzraFpgvMtCkJTZw2pH1PID67vk8YDjQmY0NODMqfOYZ5AD9ZjOahmUfmc97wlNQZ837j5OE7hcpQ8XpM0VrP0NTnITL4v7FrCbI7bJEeEUYB"; //257
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsFalse(isPasswordValid);
        }
        [Test]
        public void Fine()
        {
            var password = "ASDasdrtynbv23!@"; //257
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsFalse(isPasswordValid);
        }
    }
}
