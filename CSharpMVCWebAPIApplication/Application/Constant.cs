using CSharpMVCWebAPIApplication.Service.Azure.KeyVault;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharpMVCWebAPIApplication.Application
{
    public class Constant
    {
        public const string LOGGER_ACCOUNT_NAME = "csharpmvcwebapistorage";
        public const string SQL_SERVER_NAME = "csharpmvcwebapidatabaseserver";
        public const string SQL_DATABASE_NAME = "CSharpMVCWebAPIDatabase";

        private static Lazy<Constant> constantProvider = new Lazy<Constant>(() => new Constant());
        private Constant()
        {
            ISecretProvider secretProvider = KeyVaultSecretProvider.Instance;
            this.SQLAccountUserId = secretProvider.GetSecretAsync("csharpmvcwebapikeyvault", "SQLAccountUserId").Result;
            this.SQLAccountPassword = secretProvider.GetSecretAsync("csharpmvcwebapikeyvault", "SQLAccountPassword").Result;
            this.StorageAccountKey = secretProvider.GetSecretAsync("csharpmvcwebapikeyvault", "StorageAccountKey").Result;
        }
        public static Constant Instance => constantProvider.Value;

        public string SQLAccountUserId { get; }
        public string SQLAccountPassword { get; }
        public string StorageAccountKey { get; }
    }
}