using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EnterpriseCenterWeb.Services.Logging
{
    public class NLogService : ILogService
    {
        private readonly Logger logger;

        public static string DirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");

        public NLogService(string target)
        {
            logger = LogManager.GetLogger(target);
        }
        public LogResult Log(string message, Guid guid, LogLvl logLevel)
        {
            var msg = ParseGuidAndHeader(guid, message);
            switch (logLevel)
            {
                case LogLvl.Debug:
                    logger.Debug(msg);
                    break;
                case LogLvl.Warn:
                    logger.Warn(msg);
                    break;
                case LogLvl.Error:
                    logger.Error(msg);
                    break;
                default:
                    logger.Info(msg);
                    break;
            }

            return new LogResult()
            {
                Response = true,
                Succeded = true
            };
        }

        public LogResult Log<T>(T data,LogLvl logLevel = LogLvl.Info)
        {
            switch (logLevel)
            {
                case LogLvl.Debug:
                    logger.Debug(value: data);
                    break;
                case LogLvl.Warn:
                    logger.Warn(value: data);
                    break;
                case LogLvl.Error:
                    logger.Error(value: data);
                    break;
                default:
                    logger.Info(value: data);
                    break;
            }

            return new LogResult()
            {
                Response = true,
                Succeded = true
            };
        }

        private static string ParseGuidAndHeader(Guid guid, string header)
        {
            return $"GUID: {guid}" + (string.IsNullOrWhiteSpace(header) ? " | " + header : "");
        }

        public LogResult LogException(Exception ex, Guid guid, string header = "")
        {
            logger.Error(ex, ParseGuidAndHeader(guid, header));
            return new LogResult()
            {
                Response = true,
                Succeded = true,
            };
        }
    }
}
