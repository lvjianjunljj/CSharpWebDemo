using System;
using Microsoft.WindowsAzure.Storage; // Namespace for Storage Client Library
using Microsoft.WindowsAzure.Storage.Blob; // Namespace for Azure Blobs
using Microsoft.WindowsAzure.Storage.File; // Namespace for Azure Files

namespace CSharpMVCWebAPIApplication.Application
{
    public enum LogType
    {
        Error,
        Warning,
        Info
    }

    class Logger
    {
        private enum WriteWay
        {
            Cover,
            Append
        }
        private string className;
        public Logger(string className)
        {
            this.className = className;
        }
        public void writeLog(LogType logType, string logContent)
        {
            string dateInfo = DateTime.Now.ToString("yyyy-MM-dd");
            string writeLogLine = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "[" + logType + "]" +
                this.className + ": " + logContent;
            WriteLogLine(WriteWay.Append, writeLogLine, "logs", "TestLogs", dateInfo + ".log");
        }
        static string invalidExistLogFilePath = "[Error] log file path input is invalid";
        private void WriteLogLine(WriteWay writeWay, string writeLogLine, params string[] logFilePath)
        {
            if (logFilePath.Length < 2)
            {
                Console.WriteLine(invalidExistLogFilePath);
                return;
            }

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                @"DefaultEndpointsProtocol=https;AccountName=" + Constant.LOGGER_ACCOUNT_NAME + ";AccountKey=" +
                Constant.LOGGER_ACCOUNT_KEY);
            CloudFileClient fileClient = storageAccount.CreateCloudFileClient();

            CloudFileShare share = fileClient.GetShareReference(logFilePath[0]);

            if (!share.Exists())
            {
                share.Create();
            }
            CloudFileDirectory sampleDir = share.GetRootDirectoryReference();

            for (int i = 1; i < logFilePath.Length - 1; i++)
            {
                CloudFileDirectory nextLevelDir = sampleDir.GetDirectoryReference("TestLogs");
                if (!sampleDir.Exists())
                {
                    sampleDir.Create();
                }
                sampleDir = nextLevelDir;
            }

            CloudFile file = sampleDir.GetFileReference(logFilePath[logFilePath.Length - 1]);

            string writenLineContent = "";
            if (file.Exists())
            {
                if (writeWay == WriteWay.Cover)
                {
                }
                else if (writeWay == WriteWay.Append)
                {
                    writenLineContent = file.DownloadTextAsync().Result;
                }
            }
            file.UploadText(writenLineContent + writeLogLine + "\n");
        }

        public static void OutputLogContent(params string[] logFilePath)
        {
            if (logFilePath.Length < 2)
            {
                Console.WriteLine(invalidExistLogFilePath);
                return;
            }
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                @"DefaultEndpointsProtocol=https;AccountName=" + Constant.LOGGER_ACCOUNT_NAME +
                ";AccountKey=" + Constant.LOGGER_ACCOUNT_KEY);
            CloudFileClient fileClient = storageAccount.CreateCloudFileClient();

            CloudFileShare share = fileClient.GetShareReference(logFilePath[0]);

            if (!share.Exists())
            {
                Console.WriteLine(invalidExistLogFilePath);
                return;
            }
            CloudFileDirectory sampleDir = share.GetRootDirectoryReference();

            for (int i = 1; i < logFilePath.Length - 1; i++)
            {
                CloudFileDirectory nextLevelDir = sampleDir.GetDirectoryReference("TestLogs");
                if (!sampleDir.Exists())
                {
                    Console.WriteLine(invalidExistLogFilePath);
                    return;
                }
                sampleDir = nextLevelDir;
            }

            CloudFile file = sampleDir.GetFileReference(logFilePath[logFilePath.Length - 1]);

            if (file.Exists())
            {
                Console.WriteLine(file.DownloadTextAsync().Result);
            }
            else
            {
                Console.WriteLine();
            }
        }
    }
}