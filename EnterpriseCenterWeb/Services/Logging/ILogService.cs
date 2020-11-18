using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnterpriseCenterWeb.Services.Logging
{
    public class LogResult
    {
        public bool Succeded = false;

        public Guid Guid;

        public object Response;
    }

    public interface ILogService
    {
        public LogResult Log(object data, Guid guid, string header = "");
    }
}
