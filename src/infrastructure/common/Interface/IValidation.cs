using System.Threading.Tasks;
using FluentValidation;

namespace cashflow.infrastructure.common
{
    public interface IValidation<T> where T : class
    {
        Task ValidateAsync(T dto, AbstractValidator<T> validator);
    }
}