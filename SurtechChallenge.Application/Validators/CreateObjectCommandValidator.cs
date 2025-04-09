using FluentValidation;
using SurtechChallenge.Application.Features.Objects.Commands;

namespace SurtechChallenge.Application.Validators;

public class CreateObjectCommandValidator : AbstractValidator<CreateObjectCommand>
{
    public CreateObjectCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

        RuleFor(x => x.Data)
            .NotNull().WithMessage("Data is required.")
            .Must(d => d.Count > 0).WithMessage("Data must have at least one field.");
    }
}
