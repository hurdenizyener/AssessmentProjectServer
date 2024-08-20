using Application.Features.Positions.Constans;
using FluentValidation;

namespace Application.Features.Positions.Commands.Update;

public sealed class UpdatePositionCommandValidator : AbstractValidator<UpdatePositionCommand>
{
    public UpdatePositionCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty()
            .WithMessage(PositionValidationExceptionMessages.PositionIdCannotBeEmpty);

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