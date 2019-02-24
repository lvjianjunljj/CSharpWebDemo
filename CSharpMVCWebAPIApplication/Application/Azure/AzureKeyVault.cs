using System;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.Services.AppAuthentication;

namespace CSharpMVCWebAPIApplication.Application.Azure
{
    public class AzureKeyVault
    {
        // string connectionString = AzureKeyVault.GetSecret("datacopdev", "ServiceBusConnectionString");
        // string connectionString = AzureKeyVault.GetSecret("csharpmvcwebapikeyvault", "AppSecret");


        // It is just lie a online key-value NoSql.

        // It is using managed identities for Azure resources. 
        // So there is no other certification when get the secret from keyvault in Azure.
        public static string GetSecret(string secretName)
        {
            // It is using managed identities for Azure resources. 
            // So there is no other certification when get the secret from keyvault in Azure.
            AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider();
            KeyVaultClient keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
            string vaultUri = "https://csharpmvcwebapikeyvault.vault.azure.net/";
            SecretBundle secret = keyVaultClient.GetSecretAsync(vaultUri, secretName).Result;
            return secret.Value;
        }

        public static string GetSecret(string keyVaultName, string secretName)
        {
            // It is using managed identities for Azure resources. 
            // So there is no other certification when get the secret from keyvault in Azure.
            AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider();
            KeyVaultClient keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
            string vaultUri = $"https://{keyVaultName}.vault.azure.net/";
            SecretBundle secret = keyVaultClient.GetSecretAsync(vaultUri, secretName).Result;
            return secret.Value;
        }
        public async Task<string> GetSecretAsync(string secretName)
        {
            AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider();
            KeyVaultClient keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
            string vaultUri = "https://csharpmvcwebapikeyvault.vault.azure.net/";
            SecretBundle secret = await keyVaultClient.GetSecretAsync(vaultUri, secretName);

            return secret.Value;
        }
        public static void MainMethod()
        {
            AzureKeyVault AzureKeyVaultClass = new AzureKeyVault();
            Task<string> azureKeyVaultTask = AzureKeyVaultClass.GetSecretAsync("AppSecret");
            Console.WriteLine(azureKeyVaultTask.Result);
            string appSecretValue = GetSecret("AppSecret");
            Console.WriteLine(appSecretValue);
        }
    }
}