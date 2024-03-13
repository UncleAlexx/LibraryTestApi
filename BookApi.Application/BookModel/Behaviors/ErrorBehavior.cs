﻿namespace BookApi.Application.BookModel.Behaviors;

internal class ErrorBehavior<TRequest, T> : IPipelineBehavior<TRequest, IResult<BookView>> where TRequest : IValidatableRequest
{
    public async Task<IResult<BookView>> Handle(TRequest request, RequestHandlerDelegate<IResult<BookView>> next, CancellationToken cancellationToken)
        => await ValidationResultExtensions.FailDbExceptionIfErrorAsync<TRequest, BookView>(next);
}

internal class IEnumerableErrorBehavior<TRequest, T> : IPipelineBehavior<TRequest, IResult<IEnumerable<BookView>>> 
    where  TRequest : IQuery<IEnumerable<BookView>, IResult<IEnumerable<BookView>>>
{
    public async Task<IResult<IEnumerable<BookView>>> Handle(TRequest request, RequestHandlerDelegate<IResult<IEnumerable<BookView>>> next, CancellationToken cancellationToken)
       => await ValidationResultExtensions.FailDbExceptionIfErrorAsync<TRequest, IEnumerable<BookView>>(next);
}