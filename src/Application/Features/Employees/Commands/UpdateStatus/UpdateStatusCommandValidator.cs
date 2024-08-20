using Application.Features.Employees.Constans;
using FluentValidation;

namespace Application.Features.Employees.Commands.UpdateStatus;

public sealed class UpdateStatusCommandValidator : AbstractValidator<UpdateStatusCommand>
{
    public UpdateStatusCommandValidator()
    {
        RuleFor(u => u.Id)
            .NotEmpty()
            .WithMessage(EmployeeValidationExceptionMessages.EmployeeIdCannotBeEmpty);

        RuleFor(u => u.Status)
            .NotNull()
            .WithMessage(EmployeeValidationExceptionMessages.StatusCannotBeEmpty);


    }
}