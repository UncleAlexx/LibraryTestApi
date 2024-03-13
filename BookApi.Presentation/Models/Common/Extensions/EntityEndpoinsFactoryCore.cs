using System.Diagnostics;

namespace Library.Presentation.Models.Common.Extensions;

internal static partial class EntityEndpointsFactory
{
    private static readonly Type _messageResult = typeof(MessageResult<>);
    private static ValidationProblem CreateValidationProblem<TResultType, TRequestResult>(ValidationResult<TResultType> 
        result) => result.Successful? TypedResults.ValidationProblem(_emptyErrors) :
         TypedResults.ValidationProblem(type: nameof(ValidationException), errors:
             result.Errors!.GroupBy(failure => 
             failure.PropertyName?[..(failure.PropertyName switch { var a when a.IndexOf('.') is - 1 => a.Length, var a => a.IndexOf('.')})] ??"", 
             failure => failure.ErrorMessage??"").
             ToDictionary(keyGrouping => keyGrouping.Key, valueGrouping => valueGrouping.ToArray()));

    private async static Task<Results<TResult, ValidationProblem, ProblemHttpResult>> CreateRequestBase
        <TResultType, TRequestResult, TResult, TSelectorParameter>(ISender sender, IGeneric<TResultType, TRequestResult> query, 
        Func<TResultType, TSelectorParameter> TParameterSelector, Func<string, TSelectorParameter, TResult>? 
        TParameterizedSelector = null, string route = "", Func<TSelectorParameter, TResult>? TResultSelector = null) 
        where TRequestResult : IResult<TResultType> where TResult : class, IResult
    {
        var result = await sender.Send(query);
        return result.Successful ? TParameterizedSelector?.Invoke(route, TParameterSelector(result.Entity!)) ?? 
            TResultSelector!(TParameterSelector(result.Entity!)) : result.GetType().GetGenericTypeDefinition() switch
        {
            var type when type == _messageResult => TypedResults.Problem(statusCode: 
                Unsafe.As<TRequestResult?, MessageResult<TResultType>>(ref result).OperationCode,
            instance: (Unsafe.As<TRequestResult?, MessageResult<TResultType>>(ref result)).Message, type: "Http Error"),
            _ => CreateValidationProblem<TResultType, TRequestResult>(Unsafe.As<TRequestResult?, ValidationResult<TResultType>>(ref result))
        };
    }

    private static readonly Dictionary<string, string[]> _emptyErrors = [];
}
