namespace Library.Application.BookModel.Behaviors;

internal sealed class IsbnValidationBehavior<TRequest, TResponse>(IValidator<IsbnObject> validator) : 
    IPipelineBehavior<TRequest, IResult<BookView>> where TRequest : IIsbnValidatable
{
    private readonly IValidator<IsbnObject> _validator = validator;

    public async Task<IResult<BookView>> Handle(TRequest request, RequestHandlerDelegate<IResult<BookView>> next, 
        CancellationToken cancellationToken) => await (await _validator.ValidateAsync(IsbnObject.Create(request.Isbn).Entity!)).
        FailValidationIfInvalidAsync(next);
}
