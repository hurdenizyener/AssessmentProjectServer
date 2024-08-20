using Application.Features.Positions.Constans;
using FluentValidation;

namespace Application.Features.Positions.Commands.Create;

public sealed class CreatePositionCommandValidator : AbstractValidator<CreatePositionCommand>
{
    public CreatePositionCommandValidator()
    {
        RuleFor(p => p.DepartmentId)
            .NotEmpty()
            .WithMessage(PositionValidationExceptionMessages.DepartmanIdCannotBeEmpty);


        RuleFor(p => p.Title)
            .NotEmpty()
            .WithMessage(PositionValidationExceptionMessages.PositionTitleCannotBeEmpty)
            .MinimumLength(5)
            .WithMessage(PositionValidationExceptionMessages.PositionTitleMinimumLength)
            .MaximumLength(100)
            .WithMessage(PositionValidationExceptionMessages.PositionTitleMaximumLength);
    }
}