using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace cashflow.infrastructure.common
{
    public class Logger<T> : ILogger<T> where T : class
    {
        private readonly Microsoft.Extensions.Logging.ILogger<T> _logger;
        public Logger(Microsoft.Extensions.Logging.ILogger<T> logger)
        {
            _logger = logger;
        }

        public void LogInformation(string message)
        {
            _logger.LogInformation(message);

            Console.WriteLine($"{DateTime.UtcNow.ToLongTimeString} - At {typeof(T).Name} - LogInformation: {message}");
        }

        public void LogError(string message)
        {
            _logger.LogError(message);

            Console.WriteLine($"{DateTime.UtcNow.ToLongTimeString} - At {typeof(T).Name} - LogError: {message}");
        }

        public void LogWarning(string message)
        {
            _logger.LogWarning(message);

            Console.WriteLine($"{DateTime.UtcNow.ToLongTimeString} - At {typeof(T).Name} - LogWarning: {message}");
        }

        public void LogCritical(string message)
        {
            _logger.LogCritical(message);

            Console.WriteLine($"{DateTime.UtcNow.ToLongTimeString} - At {typeof(T).Name} - LogCritical: {message}");
        }

        public void LogTrace(string message)
        {
            _logger.LogTrace(message);

            Console.WriteLine($"{DateTime.UtcNow.ToLongTimeString} - At {typeof(T).Name} - LogTrace: {message}");
        }
    }
}