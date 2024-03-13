namespace Library.Domain.Common.Errors.ErrorKinds;

public sealed class OperationFailedError<T>(in Operation operation, in string criteria, in Databases db, 
     in string criteriaName) : IError
{
    public string Message { get; init; }  = 
        $"Cannot {operation} {typeof(T).Name} because  {typeof(T).Name} with {criteriaName} =  " +
        $"{criteria} doesn't exist in database {db}";
}
