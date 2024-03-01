namespace Library.Application.Common.Validation.Extensions;

internal static class ValidationResultExtensions
{
    public async static Task<MessageResult<BookView>> FailDbExceptionIfErrorAsync(RequestHandlerDelegate<MessageResult<BookView>> next)
        => await FailDbExceptionBaseAsync(next, MessageResult<BookView>.Failed(new DbDown(Databases.Library).Message, 503));

    public async static Task<IResult<TResult>> FailDbExceptionIfErrorAsync<TRequest, TResult>(RequestHandlerDelegate<IResult<TResult>> next)
        => await FailDbExceptionBaseAsync(next, MessageResult <TResult>.Failed(new DbDown(Databases.Library).Message, 503));

    private async static Task<T> FailDbExceptionBaseAsync<T>(RequestHandlerDelegate<T> onSuccess, T instance)
    {
        try
        {
            return await onSuccess();
        }
        catch
        {
            return instance;
        }
    }

    public async static Task<IResult<T>> FailValidationIfInvalidAsync<T>(this ValidationResult result,
        RequestHandlerDelegate<IResult<T>> onSuccess) =>
        result.IsValid ? await onSuccess() : ValidationResult<T>.Failed(result.Errors, 400);
}
