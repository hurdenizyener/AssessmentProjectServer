﻿using Application.Common.Exceptions.Types;
using FluentValidation;
using MediatR;
using ValidationException = Application.Common.Exceptions.Types.ValidationException;

namespace Application.Common.Pipelines.Validation;

public sealed class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        ValidationContext<object> context = new(request);

        //Tüm doğrulama hataları alıp bir listeye koyup kullanıca sunuyoruz
        IEnumerable<ValidationExceptionModel> errors = _validators
            .Select(validator => validator.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(failure => failure != null)
            .GroupBy(
              keySelector: p => p.PropertyName,
              resultSelector: (propertyName, errors) =>
                new ValidationExceptionModel
                {
                    Property = propertyName,
                    Errors = errors.Select(e => e.ErrorMessage)
                }
            ).ToList();

        if (errors.Any())
            throw new ValidationException(errors);

        TResponse response = await next();
        return response;
    }
}
