using System;

namespace cashflow.infrastructure.common
{
    public class ExceptionHandler : IExceptionHandler
    {
        public string MessageException { get; set; }
        public int Code { get; set; }
        public string Action { get; set; }

        public ExceptionHandler Handler(Exception e)
        {
            string message = string.Empty;

            message = $"An exception of type {e.GetType().FullName} occored.\n" +
                      $"Message: {e.Message}\n" +
                      $"Stack Trace: {e.StackTrace.Trim()}\n";

            Exception ie = e.InnerException;

            if (ie != null)
            {
                message += "Inner Exception\n" +
                $"Execption Name: {ie.GetType().Name}\n" +
                $"Message: {ie.Message}\n" +
                $"Stack Trace: {ie.StackTrace}";
            }
            MessageException = message;
            Code = GetCode(e);
            Action = GetAction(e);

            return this;
        }

        protected string GetAction(Exception e)
        {
            string action = string.Empty;

            switch (e.GetType().Name)
            {
                case "ArgumentException":
                    return string.Empty;
                default:
                    return string.Empty;
            }
        }

        protected int GetCode(Exception e)
        {
            switch (e.GetType().Name)
            {
                case "ArgumentException":
                    return 500;
                default:
                    return 500;
            }
        }
    }
}