using System.Threading.Tasks;
using System;
using FluentValidation;

namespace cashflow.infrastructure.common
{
    public class Validation<T> : IValidation<T> where T : class
    {
        public async Task ValidateAsync(T dto, AbstractValidator<T> validator)
        {
            if (dto == null)
                throw new Exception("Records not found!");

            var result = await validator.ValidateAsync(dto);

            if (!string.IsNullOrEmpty(result.ToString()))
                throw new ValidationException(result.ToString());
        }
    }
}