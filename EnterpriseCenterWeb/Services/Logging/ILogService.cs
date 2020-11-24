using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnterpriseCenterWeb.Services.Logging
{
    public class LogResult
    {
        public bool Succeded = false;

        public object Response;
    }

    public enum LogLvl
    {
        Debug = 0,
        Info = 1,
        Warn = 2,
        Error = 3,
    }

    public interface ILogService
    {
        public LogResult Log(string message, Guid guid, LogLvl logLevel);

        public LogResult Log<T>(T data, LogLvl logLevel);

        public LogResult LogException(Exception ex, Guid guid, string header = "");
    }
}
