using Application.Features.Employees.Constans;
using FluentValidation;

namespace Application.Features.Employees.Commands.Update;

public sealed class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeCommandValidator()
    {
        RuleFor(e => e.Id)
            .NotEmpty()
            .WithMessage(EmployeeValidationExceptionMessages.EmployeeIdCannotBeEmpty);

        RuleFor(e => e.DepartmentId)
            .NotEmpty()
            .WithMessage(EmployeeValidationExceptionMessages.DepartmanCannotBeEmpty);

        RuleFor(e => e.PositionId)
            .NotEmpty()
            .WithMessage(EmployeeValidationExceptionMessages.PositionCannotBeEmpty);

        RuleFor(e => e.FirstName)
            .NotEmpty()
            .WithMessage(EmployeeValidationExceptionMessages.FirstNameCannotBeEmpty)
            .MinimumLength(2)
            .WithMessage(EmployeeValidationExceptionMessages.FirstNameMinimumLength)
            .MaximumLength(60)
            .WithMessage(EmployeeValidationExceptionMessages.FirstNameMaximumLength);

        RuleFor(e => e.LastName)
            .NotEmpty()
            .WithMessage(EmployeeValidationExceptionMessages.LastNameCannotBeEmpty)
            .MinimumLength(2)
            .WithMessage(EmployeeValidationExceptionMessages.LastNameMinimumLength)
            .MaximumLength(60)
            .WithMessage(EmployeeValidationExceptionMessages.LastNameMaximumLength);

        RuleFor(e => e.Gender)
            .NotEmpty()
            .WithMessage(EmployeeValidationExceptionMessages.GenderCannotBeEmpty)
            .MinimumLength(1)
            .WithMessage(EmployeeValidationExceptionMessages.GenderMinimumLength)
            .MaximumLength(5)
            .WithMessage(EmployeeValidationExceptionMessages.GenderMaximumLength);

        RuleFor(e => e.Phone)
            .NotEmpty()
            .WithMessage(EmployeeValidationExceptionMessages.PhoneCannotBeEmpty)
            .MinimumLength(10)
            .WithMessage(EmployeeValidationExceptionMessages.PhoneMinimumLength)
            .MaximumLength(20)
            .WithMessage(EmployeeValidationExceptionMessages.PhoneMaximumLength);

        RuleFor(c => c.Email)
            .NotEmpty()
            .WithMessage(EmployeeValidationExceptionMessages.EmailCannotBeEmpty)
            .EmailAddress()
            .WithMessage(EmployeeValidationExceptionMessages.EmailAddressValid)
            .MaximumLength(255)
            .WithMessage(EmployeeValidationExceptionMessages.EmailMaximumLength);

        RuleFor(e => e.GraduatedSchool)
            .NotEmpty()
            .WithMessage(EmployeeValidationExceptionMessages.GraduatedSchoolCannotBeEmpty)
            .MinimumLength(12)
            .WithMessage(EmployeeValidationExceptionMessages.GraduatedSchoolMinimumLength)
            .MaximumLength(255)
            .WithMessage(EmployeeValidationExceptionMessages.GraduatedSchoolMaximumLength);

        RuleFor(e => e.GraduatedField)
            .NotEmpty()
            .WithMessage(EmployeeValidationExceptionMessages.GraduatedFieldCannotBeEmpty)
            .MinimumLength(10)
            .WithMessage(EmployeeValidationExceptionMessages.GraduatedFieldMinimumLength)
            .MaximumLength(255)
            .WithMessage(EmployeeValidationExceptionMessages.GraduatedFieldMaximumLength);

        RuleFor(e => e.BirthDate)
            .NotEmpty()
            .WithMessage(EmployeeValidationExceptionMessages.BirthDateCannotBeEmpty);

        RuleFor(e => e.DateOfEntry)
            .NotEmpty()
            .WithMessage(EmployeeValidationExceptionMessages.DateOfEntryCannotBeEmpty);
    }
}