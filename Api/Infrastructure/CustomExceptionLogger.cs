using Instrastructure.Logging;
using System.Web.Http.ExceptionHandling;

namespace Api.Infrastructure
{
    public class CustomExceptionLogger : ExceptionLogger
    {
        ILogger _logger;

        public CustomExceptionLogger(ILogger logger)
        {
            _logger = logger;
        }

        public override void Log(ExceptionLoggerContext context)
        {
            _logger.LogError("Unhandled Exception", context.Exception);
        }
    }
}