using System;

namespace Instrastructure.Logging
{
    public interface ILogger
    {
        void LogError(string message, Exception exception);
        void LogWarning(string message);
    }
}