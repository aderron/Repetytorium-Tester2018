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
            var key = "THE_KEY";
            var remoteAddress = "SOME_REMOTE_ADDRESS";

            var sut = new ResourceManager(connectorMock.Object, encryptionMock.Object, key);

            // Act
            sut.Get(remoteAddress);

            // Assert
            connectorMock.Verify(m => m.GetContent(remoteAddress), Times.Once); // sprawdza czy metoda została zawołana
            connectorMock.Verify(m => m.PostContent(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            // Verify IEncryption
            encryptionMock.Verify(m => m.Decrypt(It.IsAny<string>(), key), Times.Once);
            encryptionMock.Verify(m => m.Encrypt(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void Post_VerifyIfCallsRightMethods()
        {
            // Arange
            var connectorMock = new Mock<IConnector>();
            var encryptionMock = new Mock<IEncryption>();
            var key = "THE_KEY";
            var remoteAddress = "SOME_REMOTE_ADDRESS";
            var content = "THE_CONTENT";

            var sut = new ResourceManager(connectorMock.Object, encryptionMock.Object, key);

            // Act
            sut.Push(remoteAddress, content);

            // Assert
            // czy zaszyfujemy
            encryptionMock.Verify(m => m.Encrypt(content, key), Times.Once);
            // czy wyślemy
            connectorMock.Verify(m => m.PostContent(remoteAddress, It.IsAny<string>()), Times.Once);
            // NIE odbieramy
            connectorMock.Verify(m => m.GetContent(It.IsAny<string>()), Times.Never);
            // nie rozszyfrowujemy
            encryptionMock.Verify(m => m.Decrypt(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            
        }
    }
}
