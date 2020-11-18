using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EnterpriseCenterWeb.Services.Logging
{
    public class LogToFileService : ILogService
    {
        public static string DirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");

        public LogToFileService(string directory)
        {
            if (!string.IsNullOrWhiteSpace(directory) || !Uri.IsWellFormedUriString(directory, UriKind.RelativeOrAbsolute))
            {
                DirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
            }

            DirectoryPath = Directory.CreateDirectory(directory).FullName;
        }

        public LogResult Log(object data, Guid guid, string header = "")
        {
            return new LogResult()
            {
                Guid = guid,
                Response = true,
                Succeded = true
            };
        }

        public LogResult LogException(Exception ex, Guid guid, string header = "")
        {
            throw new NotImplementedException();
        }
    }
}
