namespace CSharpMVCWebAPIApplication.Service.Azure.KeyVault
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.Azure.KeyVault;
    using Microsoft.Azure.KeyVault.Models;
    using Microsoft.Azure.Services.AppAuthentication;

    public class KeyVaultSecretProvider : ISecretProvider
    {
        private static Lazy<KeyVaultSecretProvider> secretProvider = new Lazy<KeyVaultSecretProvider>(() => new KeyVaultSecretProvider());

        private KeyVaultSecretProvider()
        {
        }

        public static KeyVaultSecretProvider Instance => secretProvider.Value;

        /// <summary>
        /// Get secret from Azure Key Vault using the managed crediential.
        /// Details see https://github.com/Azure-Samples/app-service-msi-keyvault-dotnet
        /// </summary>
        /// <param name="keyVaultName"></param>
        /// <param name="secretName"></param>
        /// <returns></returns>
        public async Task<string> GetSecretAsync(string keyVaultName, string secretName)
        {
            AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider();
            KeyVaultClient keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
            string vaultUri = $"https://{keyVaultName}.vault.azure.net/";
            SecretBundle secret = await keyVaultClient.GetSecretAsync(vaultUri, secretName);
            return secret.Value;
        }
    }
}