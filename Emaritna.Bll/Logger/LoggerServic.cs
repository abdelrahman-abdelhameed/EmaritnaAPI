using Microsoft.Extensions.Logging;

namespace Emaritna.Bll.Logger
{
    public class LoggerService<T> : ILoggerService<T> where T : class
    {
        private readonly ILogger<T> _logger;

        public LoggerService(ILogger<T> logger)
        {
            this._logger = logger;
        }

        public void LogErrorData(string error)
        {
            _logger.LogError(error);
        }
    }
}