using Moq;
using NUnit.Framework;

namespace EulerLibrary2.Mock
{
    [TestFixture]
    public class ResourceManagerTests
    {
        [Test]
        public void Get_VerifyIfCallsRightMethods()
        {
            // Arange
            var connectorMock = new Mock<IConnector>();
            var encryptionMock = new Mock<IEncryption>();
            var key = "XXX";
            var resourceName = "RES";

            var x = new ResourceManager(connectorMock.Object, encryptionMock.Object, key);

            // Act
            x.Get(resourceName);

            // Assert
            connectorMock.Verify(m => m.GetContent(resourceName), Times.Once); // sprawdza czy metoda została zawołana
            connectorMock.Verify(m => m.PostContent(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            // Verify IEncryption
        }

        [Test]
        public void Post_VerifyIfCallsRightMethods()
        {
            // Arange
            var connectorMock = new Mock<IConnector>();
            var encryptionMock = new Mock<IEncryption>();
            var key = "XXX";
            var resourceName = "RES";
            var content = "Content";

            var x = new ResourceManager(connectorMock.Object, encryptionMock.Object, key);

            // Act

            // Assert
        }
    }
}
