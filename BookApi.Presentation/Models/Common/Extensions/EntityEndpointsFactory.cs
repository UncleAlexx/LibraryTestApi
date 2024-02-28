
using BookApi.Application.Common.Abstractions.Requests;
using BookApi.Domain.Book;
using BookApi.Domain.Common.Results.Common;
using BookApi.Domain.Common.Results.Interfaces;
using BookApi.Domain.Common.Results.ResultsKind;
using BookApi.Presentation.Contracts.Book.Common.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Autoservice.Presentation;

internal static partial class EntityEndpointsFactory
{
    public async static Task<Results<m, ValidationProblem, ProblemHttpResult>> CreateRequest<TResultType, TRequestResult, TType,m>(ISender sender,
       IGeneric<TResultType, TRequestResult> query, Func<TResultType, TType> k,Func<string,TType,m>? criteria, string criteria2 = "")
      where TRequestResult : IResult<TResultType> where TType : ResponseBase<TResultType> where m : class, IResult
        => await CreateRequestBase(sender, query, k, criteria, criteria2);

    public async static Task<Results<m, ProblemHttpResult>> CreateRequest<TResultType, TRequestResult, TType, m>(ISender sender,
         IEnumerableQuery<TResultType, TRequestResult> query, Func<IEnumerable<TResultType>, TType> criteria, Func<TType, m> p)
      where TRequestResult : IResult<IEnumerable<TResultType>> where m : class, IResult
    {
        var result = await sender.Send(query);
        return result.Successful ? p(criteria(result.Entity!)): TypedResults.Problem(statusCode: result is null ? 503 : 404, instance:
            (result as MessageResult<IEnumerable<TResultType>>).Message, type: "Http Error");
    }

    public async static Task<Results<m, ValidationProblem, ProblemHttpResult>> CreateRequest<TResultType, TRequestResult, TType,m>(ISender sender,
        IGeneric<TResultType, TRequestResult> query,Func<TResultType, TType> sdfdf , Func<TType, m> p)
      where TRequestResult : IResult<TResultType>  where TType : ResponseBase<TResultType> where m: class,IResult
        => await CreateRequestBase(sender,query, sdfdf, crit2: p);
}
