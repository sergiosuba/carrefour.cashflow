using FluentValidation;
using System;
using cashflow.domain.DTO;

namespace cashflow.domain.Validators
{
    public class AccountingEntryValidator : AbstractValidator<AccountingEntryDTO>
    {
        public AccountingEntryValidator()
        {
            RuleFor(x => x.Id)
                .Must(g => Guid.TryParse(g, out Guid guid))
                .WithMessage("The Id value must contain a valid guid.");

            RuleFor(x => x.ChartAccountId)
                .Must(g => Guid.TryParse(g, out Guid guid))
                .WithMessage("The ChartAccountId value must contain a valid guid.");

            RuleFor(x => x.Value)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0)
                .WithMessage("The Value value should be greater than 0.");

            RuleFor(x => x.FlowId)
                .Must(g => Guid.TryParse(g, out Guid guid))
                .WithMessage("The FlowId value must contain a valid guid.");

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
