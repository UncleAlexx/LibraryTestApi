namespace Library.Presentation.Endpoints.Common.Extensions;

internal static partial class EntityEndpointsFactory
{
    public async static Task<Results<THttpResult, ValidationProblem, ProblemHttpResult>> CreateRequest<TIResult, 
        TResponse, IResultResult, THttpResult> (ISender sender, IGeneric<TIResult, TResponse> query, 
        Func<TIResult, IResultResult> resultBaseSelector, Func<string, IResultResult, THttpResult>? 
        parameterizedResultSelector, string parameterizedSelectorArg = "") where TResponse : IResult<TIResult> 
        where IResultResult : ResponseBase<TIResult> where THttpResult : class, IResult => 
        await CreateRequestBase(sender, query, resultBaseSelector, parameterizedResultSelector, parameterizedSelectorArg);

    public async static Task<Results<THttpResult, ProblemHttpResult>> CreateRequest<TEntity, TResponse, TResultBase, 
        THttpResult>(ISender sender,  IEnumerableQuery<TEntity, TResponse> query, Func<IEnumerable<TEntity>,
            TResultBase> resultBaseSelector, Func<TResultBase, THttpResult> httpResultSelector) where TResponse : 
        IMessageResult<IEnumerable<TEntity>, TResponse>, IResult<IEnumerable<TEntity>> where THttpResult : class, 
        IResult
    {
        var result = await sender.Send(query);
        return result.Successful ? httpResultSelector(resultBaseSelector(result.Entity!)): 
            TypedResults.Problem(statusCode: result.OperationCode, instance: result!.Message, type: "Http Error");
    }

    public async static Task<Results<THttpResult, ValidationProblem, ProblemHttpResult>> CreateRequest
        <TResultBase, TRequestResult, IResultResult,THttpResult>(ISender sender, 
        IGeneric<TResultBase, TRequestResult> query, Func<TResultBase, IResultResult> IResultResultSelector, 
        Func<IResultResult, THttpResult> THttpResultSelector)
      where TRequestResult : IResult<TResultBase>  where IResultResult : ResponseBase<TResultBase> where 
        THttpResult: class, IResult  => await CreateRequestBase(sender,query, IResultResultSelector,
            TResultSelector: THttpResultSelector);
}
