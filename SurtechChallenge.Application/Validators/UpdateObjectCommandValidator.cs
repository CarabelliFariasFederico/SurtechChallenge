using FluentValidation;
using SurtechChallenge.Application.Features.Objects.Commands;

namespace SurtechChallenge.Application.Validators;

public class UpdateObjectCommandValidator : AbstractValidator<UpdateObjectCommand>
{
    public UpdateObjectCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.");

        RuleFor(x => x.Data)
            .NotNull().WithMessage("Data is required.")
            .Must(d => d.Count > 0).WithMessage("Data must contain at least one field.");
    }
}
