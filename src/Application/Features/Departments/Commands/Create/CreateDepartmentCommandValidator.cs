using Application.Features.Departments.Constans;
using FluentValidation;

namespace Application.Features.Departments.Commands.Create;

public sealed class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
{
    public CreateDepartmentCommandValidator()
    {
        RuleFor(d => d.Name)
            .NotEmpty()
            .WithMessage(DepartmentValidationExceptionMessages.DepartmanNameCannotBeEmpty)
            .MinimumLength(5)
            .WithMessage(DepartmentValidationExceptionMessages.DepartmanNameMinimumLength)
            .MaximumLength(100)
            .WithMessage(DepartmentValidationExceptionMessages.DepartmanNameMaximumLength);
    }
}