using FluentValidation;
using System;
using cashflow.domain.DTO;

namespace cashflow.domain.Validators
{
    public class ChartAccountValidator : AbstractValidator<ChartAccountDTO>
    {
        public ChartAccountValidator()
        {
            RuleFor(x => x.Id)
                .Must(g => Guid.TryParse(g, out Guid guid))
                .WithMessage("The Id value must contain a valid guid.");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("The Description value should be beetween 3 and 400 characters.")
                .NotEmpty().WithMessage("The Description value should be beetween 3 and 400 characters.")
                .Must(x => x.Length >= 3 && x.Length <= 400)
                .WithMessage("The Description value should be beetween 3 and 400 characters.");

            RuleFor(x => x.Description)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("The Description value should be beetween 3 and 400 characters.")
                .NotEmpty().WithMessage("The Description value should be beetween 3 and 400 characters.")
                .Must(x => x.Length >= 3 && x.Length <= 400)
                .WithMessage("The Description value should be beetween 3 and 400 characters.");

            RuleFor(x => x.CreationDate)
                .Must(d => DateTime.TryParse(d.ToString(), out DateTime dateTime))
                .WithMessage("The Creation Date value must contain a valid date time.");
        }
    }
}
