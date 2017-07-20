using NLog;

namespace Logic.Loggers
{
    public class CustomLogger : ILogger
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public void Debug(string message) => _logger.Debug(message);

        public void Error(string message) => _logger.Error(message);

        public void Fatal(string message) => _logger.Fatal(message);

        public void Info(string message) => _logger.Info(message);

        public void Trace(string message) => _logger.Trace(message);

        public void Warn(string message) => _logger.Warn(message);
    }
}
