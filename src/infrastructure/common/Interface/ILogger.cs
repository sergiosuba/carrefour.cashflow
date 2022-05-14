namespace cashflow.infrastructure.common
{
    public interface ILogger<T> where T : class
    {
        void LogInformation(string message);
        void LogError(string message);
        void LogWarning(string message);
        void LogCritical(string message);
        void LogTrace(string message);
    }
}