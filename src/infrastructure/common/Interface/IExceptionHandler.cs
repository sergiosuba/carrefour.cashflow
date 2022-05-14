using System;

namespace cashflow.infrastructure.common
{
    public interface IExceptionHandler
    {
        ExceptionHandler Handler(Exception e);
    }
}
