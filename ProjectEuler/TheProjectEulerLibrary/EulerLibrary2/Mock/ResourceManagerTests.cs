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
            encryptionMock.Verify(m => m.Decrypt(It.IsAny<string>(), key), Times.Once);
            encryptionMock.Verify(m => m.Encrypt(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
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
            var encryptedContent = "Encrypted Content";

            var x = new ResourceManager(connectorMock.Object, encryptionMock.Object, key);

            // Act
            x.Push(resourceName,content);

            

            // Assert
            connectorMock.Verify(m => m.GetContent(It.IsAny<string>()), Times.Never); // sprawdza czy metoda została zawołana
            connectorMock.Verify(m => m.PostContent(resourceName, It.IsAny<string>()), Times.Once);
            // Verify IEncryption
            encryptionMock.Verify(m => m.Decrypt(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            encryptionMock.Verify(m => m.Encrypt(content, key), Times.Once);




        }

        [Test]
        public void Get_VerifyIfCallsRightMethodsWithRightContent()
        {
            // Arange
            var connectorMock = new Mock<IConnector>();
            var encryptionMock = new Mock<IEncryption>();
            var key = "XXX";
            var resourceName = "RES";
            var encryptedContent = "__ENCRYPTED_CONTENT___";
            var decryptedContent = "THE_CONTENT";

            connectorMock.Setup(m => m.GetContent(resourceName)).Returns(encryptedContent);
            encryptionMock.Setup(m => m.Decrypt(encryptedContent, key)).Returns(decryptedContent);

            var x = new ResourceManager(connectorMock.Object, encryptionMock.Object, key);

            // Act
            var result = x.Get(resourceName);

            // Assert
            Assert.AreEqual(decryptedContent, result);
        }

        [Test]
        public void Push_VerifyIfCallsRightMethodsWithRightContent()
        {
            // Arange
            var connectorMock = new Mock<IConnector>();
            var encryptionMock = new Mock<IEncryption>();
            var key = "XXX";
            var resourceName = "RES";
            var encryptedContent = "__ENCRYPTED_CONTENT___";
            var decryptedContent = "THE_CONTENT";

            
            encryptionMock.Setup(m => m.Encrypt(decryptedContent, key)).Returns(encryptedContent);

            var x = new ResourceManager(connectorMock.Object, encryptionMock.Object, key);

            // Act
            x.Push(resourceName,decryptedContent);

            // Assert
            connectorMock.Verify(m => m.PostContent(resourceName, encryptedContent), Times.Once);
        }
    }
}
