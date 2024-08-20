using Application.Features.Departments.Constans;
using FluentValidation;

namespace Application.Features.Departments.Commands.Update;

public sealed class UpdateDepartmentCommandValidator : AbstractValidator<UpdateDepartmentCommand>
{
    public UpdateDepartmentCommandValidator()
    {
        RuleFor(d => d.Id)
            .NotEmpty()
            .WithMessage(DepartmentValidationExceptionMessages.DepartmentIdCannotBeEmpty);

        RuleFor(d => d.Name)
            .NotEmpty()
            .WithMessage(DepartmentValidationExceptionMessages.DepartmanNameCannotBeEmpty)
            .MinimumLength(5)
            .WithMessage(DepartmentValidationExceptionMessages.DepartmanNameMinimumLength)
            .MaximumLength(100)
            .WithMessage(DepartmentValidationExceptionMessages.DepartmanNameMaximumLength);
    }
}