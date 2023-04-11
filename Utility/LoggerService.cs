using NLog;

namespace taskaloo.Utility;

public interface ILoggerService

{
    void LogInfo(string message);
    void LogWarn(string message);
    void LogDebug(string message);
    void LogError(string message);
    void LogFatal(string message);
}
    public class LoggerService : ILoggerService
    {
        private static readonly Logger _loggerService = LogManager.GetCurrentClassLogger();
        public void LogInfo(string message)
        {
            _loggerService.Info(message);
        }
        public void LogWarn(string message)
        {
            _loggerService.Warn(message);
        }
        public void LogDebug(string message)
        {
            _loggerService.Debug(message);
        }
        public void LogError(string message)
        {
            _loggerService.Error(message);
        }
        public void LogFatal(string message)
        {
            _loggerService.Fatal(message);
        }
        
    }