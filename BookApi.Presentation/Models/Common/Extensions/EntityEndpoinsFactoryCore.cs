
using BookApi.Application.Common.Abstractions.Requests;
using BookApi.Domain.Common.Results.Interfaces;
using BookApi.Domain.Common.Results.ResultsKind;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Autoservice.Presentation;

internal static partial class EntityEndpointsFactory
{
    private static ValidationProblem CreateValidationProblem<TResultType, TRequestResult>(ValidationResult<TResultType> result)
        => result.Successful? TypedResults.ValidationProblem(_emptyErrors) :
         TypedResults.ValidationProblem(type: "ValidationException", errors:
             result.Errors.GroupBy(x => x.PropertyName, y => y.ErrorMessage).
             ToDictionary(x => x.Key, y => y.ToArray()));

    private async static Task<Results<TType, ValidationProblem, ProblemHttpResult>> CreateRequestBase<TResultType, TRequestResult, TType,m>(ISender sender,
        IGeneric<TResultType, TRequestResult> query, Func<TResultType, m> sdfdf, Func<string, m, TType>? cri2 = null, string route = "", Func<m, TType>? crit2 = null)
      where TRequestResult : IResult<TResultType> where TType : class, IResult
    {
        var result = await sender.Send(query);
        var type = result.GetType();
        return result.Successful ? cri2?.Invoke(route, sdfdf(result.Entity!)) ?? crit2!(sdfdf(result.Entity!)) : type switch
        {
            _ when type == typeof(MessageResult<TResultType>) =>
            TypedResults.Problem(statusCode: Unsafe.As<TRequestResult?, MessageResult<TResultType>>(ref result).OperationCode,
            instance: (Unsafe.As<TRequestResult?, MessageResult<TResultType>>(ref result)).Message, type: "Http Error"),
            _ => CreateValidationProblem<TResultType, TRequestResult>(Unsafe.As<TRequestResult?, ValidationResult<TResultType>>(ref result))
        };
    }

    private static readonly Dictionary<string, string[]> _emptyErrors = [];
}
