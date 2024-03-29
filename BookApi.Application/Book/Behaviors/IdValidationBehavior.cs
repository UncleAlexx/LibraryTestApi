﻿namespace Library.Application.Book.Behaviors;

internal sealed class IdValidationBehavior<TRequest, TResponse>(IValidator<IdObject> validator) : 
    IPipelineBehavior<TRequest, IResult<BookView>> where TRequest : IIdValidatable
{
    private readonly IValidator<IdObject> _validator = validator;

    public async Task<IResult<BookView>> Handle(TRequest request, RequestHandlerDelegate<IResult<BookView>> next, CancellationToken
        cancellationToken) => await (await _validator.ValidateAsync(IdObject.Create(request.Id))).FailValidationIfInvalidAsync(next);
}
