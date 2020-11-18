using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EnterpriseCenterWeb.Services.Logging
{
    public class LogToFileService : ILogService
    {
        public static string path = Path.Combine(Directory.GetCurrentDirectory(), "Logs");

        public LogToFileService(string directory)
        {
            if (!string.IsNullOrWhiteSpace(directory) || !Uri.IsWellFormedUriString(directory, UriKind.RelativeOrAbsolute))
            {
                path = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
            }

            path = Directory.CreateDirectory(directory).FullName;
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
    }
}
