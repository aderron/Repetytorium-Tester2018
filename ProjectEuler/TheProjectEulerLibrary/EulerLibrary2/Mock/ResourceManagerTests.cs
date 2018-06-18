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
            connectorMock.Verify(m => m.UpdateContent(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            // Verify IEncryption

            /*encryptionMock.Verify(m => m.Decrypt(It.IsAny<string>(), key), Times.Once);
            encryptionMock.Verify(m => m.Encrypt(It.IsAny<string>(), It.IsAny<string>()), Times.Never);*/

            encryptionMock.Verify(m=>m.Decrypt(It.IsAny<string>(), key), Times.Once); 
            encryptionMock.Verify(m=>m.Encrypt(It.IsAny<string>(), key), Times.Never);
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
            sut.Update(remoteAddress, content);




            // Assert
            // czy zaszyfujemy
            encryptionMock.Verify(m => m.Encrypt(content, key), Times.Once);
            // czy wyślemy
            connectorMock.Verify(m => m.UpdateContent(remoteAddress, It.IsAny<string>()), Times.Once);
            // NIE odbieramy
            connectorMock.Verify(m => m.GetContent(It.IsAny<string>()), Times.Never);
            // nie rozszyfrowujemy
            encryptionMock.Verify(m => m.Decrypt(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }


        [Test]
        public void Get_VerifyDecryption()
        {
            // Arange
            var connectorMock = new Mock<IConnector>();
            var encryptionMock = new Mock<IEncryption>();
            var key = "THE_KEY";
            var remoteAddress = "SOME_REMOTE_ADDRESS";
            var encryptedContent = "__ENCRYPTED_CONTENT__";
            var decryptedContent = "THE_CONTENT";

            connectorMock.Setup(m => m.GetContent(remoteAddress)).Returns(encryptedContent);
            encryptionMock.Setup(m => m.Decrypt(encryptedContent, key)).Returns(decryptedContent);

            var sut = new ResourceManager(connectorMock.Object, encryptionMock.Object, key);

            // Act
            var result = sut.Get(remoteAddress);

            // Assert
            Assert.AreEqual(decryptedContent, result);
        }

        [Test]
        public void Post_VeeifyEncryption()
        {
            // Arange
            var connectorMock = new Mock<IConnector>();
            var encryptionMock = new Mock<IEncryption>();
            var key = "THE_KEY";
            var remoteAddress = "SOME_REMOTE_ADDRESS";
            var encryptedContent = "__ENCRYPTED_CONTENT__";
            var decryptedContent = "THE_CONTENT";

            encryptionMock.Setup(m => m.Encrypt(decryptedContent, key)).Returns(encryptedContent);

            var sut = new ResourceManager(connectorMock.Object, encryptionMock.Object, key);

            // Act
            sut.Update(remoteAddress, decryptedContent);

            // Assert
            connectorMock.Verify(m => m.UpdateContent(remoteAddress, encryptedContent), Times.Once);
        }

        [Test]
        public void x()
        {
            var mock = new Mock<IPrimeTool>();
            mock.Setup(m => m.IsPrime(2)).Returns(true);
            mock.Setup(m => m.IsPrime(3)).Returns(true);
            mock.Setup(m => m.IsPrime(5)).Returns(true);

            Assert.IsTrue(mock.Object.IsPrime(2));
            Assert.IsTrue(mock.Object.IsPrime(2));
            Assert.IsTrue(mock.Object.IsPrime(2));
            Assert.IsTrue(mock.Object.IsPrime(3));
            Assert.IsTrue(mock.Object.IsPrime(5));
        }

        public interface IPrimeTool
        {
            bool IsPrime(int number);
        }
    }
}
