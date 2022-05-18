using FluentValidation;
using System;
using cashflow.domain.DTO;

namespace cashflow.domain.Validators
{
    public class FlowValidator : AbstractValidator<FlowDTO>
    {
        public FlowValidator()
        {
            RuleFor(x => x.Id)
                .Must(g => Guid.TryParse(g, out Guid guid))
                .WithMessage("The Id value must contain a valid guid.");

            RuleFor(x => x.Flow)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("The Flow value should be beetween 3 and 400 characters.")
                .NotEmpty().WithMessage("The Flow value should be beetween 3 and 400 characters.")
                .Must(x => x.Length >= 3 && x.Length <= 400)
                .WithMessage("The Description value should be beetween 3 and 400 characters.");
        }
    }
}
