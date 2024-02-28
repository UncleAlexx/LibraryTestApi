using System.Runtime.CompilerServices;
using BookApi.Domain.Common.Enums;
using BookApi.Domain.Common.Errors.Bases;

namespace BookApi.Domain.Common.Errors.ErrorKinds;

public sealed class OperationFailed<T>(Operation operation, string criteria, Databases db, 
    [CallerArgumentExpression(nameof(criteria))] string criteriaName = "") : IError
{
    public string? Message { get; init; }  = 
        $"Cannot {operation} {typeof(T).Name} because  {typeof(T).Name} with {criteriaName} =  " +
        $"{criteria} doesn't exist in database {db}";
}
