namespace Library.Application.BookModel.Behaviors;

internal sealed class PersistenceBehavior<T, TRequest>(IUnitOfWork unitOfWork) : 
    IPipelineBehavior<T, IResult<BookView>> where T : ICommand<BookView, IResult<BookView>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<IResult<BookView>> Handle(T request, RequestHandlerDelegate<IResult<BookView>> next, 
        CancellationToken cancellationToken)
    {
        var nextResult = await next();
        await _unitOfWork.SaveChangesAsync();
        return nextResult;
    }
}
