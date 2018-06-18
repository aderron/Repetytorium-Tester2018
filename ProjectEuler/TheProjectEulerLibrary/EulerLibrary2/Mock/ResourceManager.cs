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

        public string Get(string url)
        {
            var encryptedContent = this.connector.GetContent(url);
            var content = this.encryption.Decrypt(encryptedContent, this.Key);
            return encryptedContent;
        }

        public void Push(string adresInternetowy, string content)
        {
            var encryptedContent = this.encryption.Encrypt(content, this.Key);
            this.connector.PostContent(adresInternetowy, content);
        }
    }
}
