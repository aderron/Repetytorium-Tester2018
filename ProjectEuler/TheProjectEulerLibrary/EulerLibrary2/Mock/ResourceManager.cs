namespace EulerLibrary2.Mock
{
    public interface IEncryption
    {
        string Encrypt(string content, string key);
        string Decrypt(string cipher, string key);
    }

    public interface IConnector
    {
        string GetContent(string url);
        string PostContent(string url, string content);
    }

    public class ResourceManager {
        private IConnector connector;

        private IEncryption encryption;

        private string Key;

        public ResourceManager(IConnector connector, IEncryption encryption, string key)  
        {
            this.connector = connector;
            this.encryption = encryption;
            this.Key = key;
        }

        public string Get(string name)
        {
            var content = this.connector.GetContent(name);
            var decryptedContent = this.encryption.Decrypt(content, this.Key);
            return decryptedContent;
        }

        public void Push(string name, string content)
        {
            var encryptedContent = this.encryption.Encrypt(content, this.Key);
            this.connector.PostContent(name, encryptedContent);
        }
    }
}
