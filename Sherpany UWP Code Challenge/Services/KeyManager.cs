using System.Linq;
using Windows.Security.Credentials;
using Sherpany_UWP_Code_Challange.Interfaces;

namespace Sherpany_UWP_Code_Challange.Services
{
    public class KeyManager : IKeyManager
    {
        private const string PWKey = "EncryptionKey";

        public string GetEncryptionKey(bool isDemoMode)
        {
            if (isDemoMode) return "000000";

            var pwVault = new PasswordVault();
            var credentials = pwVault.FindAllByResource(PWKey);

            var credential = credentials.First();
            credential.RetrievePassword();
            return credential.Password;
        }

        public void SetEncryptionKey(string key)
        {
            DeleteEncryptionKey();
            var pwVault = new PasswordVault();
            pwVault.Add(new PasswordCredential(PWKey, "dummyname", key));
        }

        public bool DeleteEncryptionKey()
        {
            if (!IsKeySet())
                return false;

            var pwVault = new PasswordVault();
            var credentials = pwVault.FindAllByResource(PWKey);
            foreach (var credential in credentials)
            {
                pwVault.Remove(credential);
            }

            return true;
        }

        public bool IsKeySet()
        {
            var pwVault = new PasswordVault();
            var all = pwVault.RetrieveAll();
            return all.Any(c => c.Resource == PWKey);
        }
    }
}
