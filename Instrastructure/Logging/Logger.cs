using log4net;
using System;

namespace Instrastructure.Logging
{
    public class Logger : ILogger
    {
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void LogWarning(string message)
        {
            _log.Warn(message);
        }

        public void LogError(string message, Exception exception)
        {
            _log.Error(message, exception);
        }
    }
}
