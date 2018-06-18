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
<<<<<<< HEAD
            var key = "THE_KEY";
            var remoteAddress = "SOME_REMOTE_ADDRESS";

            var sut = new ResourceManager(connectorMock.Object, encryptionMock.Object, key);

            // Act
            sut.Get(remoteAddress);

            // Assert
            connectorMock.Verify(m => m.GetContent(remoteAddress), Times.Once); // sprawdza czy metoda została zawołana
            connectorMock.Verify(m => m.UpdateContent(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
=======
            var key = "XXX";
            var resourceName = "RES";

            var x = new ResourceManager(connectorMock.Object, encryptionMock.Object, key);

            // Act
            x.Get(resourceName);

            // Assert
            connectorMock.Verify(m => m.GetContent(resourceName), Times.Once); // sprawdza czy metoda została zawołana
            connectorMock.Verify(m => m.PostContent(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
>>>>>>> PiotrJMock
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
<<<<<<< HEAD
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
=======
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
>>>>>>> PiotrJMock
        {
            // Arange
            var connectorMock = new Mock<IConnector>();
            var encryptionMock = new Mock<IEncryption>();
<<<<<<< HEAD
            var key = "THE_KEY";
            var remoteAddress = "SOME_REMOTE_ADDRESS";
            var encryptedContent = "__ENCRYPTED_CONTENT__";
            var decryptedContent = "THE_CONTENT";

            connectorMock.Setup(m => m.GetContent(remoteAddress)).Returns(encryptedContent);
            encryptionMock.Setup(m => m.Decrypt(encryptedContent, key)).Returns(decryptedContent);

            var sut = new ResourceManager(connectorMock.Object, encryptionMock.Object, key);

            // Act
            var result = sut.Get(remoteAddress);
=======
            var key = "XXX";
            var resourceName = "RES";
            var encryptedContent = "__ENCRYPTED_CONTENT___";
            var decryptedContent = "THE_CONTENT";

            connectorMock.Setup(m => m.GetContent(resourceName)).Returns(encryptedContent);
            encryptionMock.Setup(m => m.Decrypt(encryptedContent, key)).Returns(decryptedContent);

            var x = new ResourceManager(connectorMock.Object, encryptionMock.Object, key);

            // Act
            var result = x.Get(resourceName);
>>>>>>> PiotrJMock

            // Assert
            Assert.AreEqual(decryptedContent, result);
        }

        [Test]
<<<<<<< HEAD
        public void Post_VeeifyEncryption()
=======
        public void Push_VerifyIfCallsRightMethodsWithRightContent()
>>>>>>> PiotrJMock
        {
            // Arange
            var connectorMock = new Mock<IConnector>();
            var encryptionMock = new Mock<IEncryption>();
<<<<<<< HEAD
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
=======
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
>>>>>>> PiotrJMock
        }
    }
}
