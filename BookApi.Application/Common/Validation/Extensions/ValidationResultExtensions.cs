using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Library.Application.Common.Validation.Extensions;

internal static class ValidationResultExtensions
{
    public async static Task<MessageResult<TResult>> FailDbExceptionIfErrorAsync<TRequest, TResult>(RequestHandlerDelegate<IResult<TResult>> next)
    {
        var a = await FailDbExceptionBaseAsync(next, MessageResult<TResult>.Failed(new DbDownError(Databases.Library).Message, 503));
        return Unsafe.As<IResult<TResult>, MessageResult<TResult>>(ref a);
    }
        

    private async static Task<TEntity> FailDbExceptionBaseAsync<TEntity>(RequestHandlerDelegate<TEntity> onSuccess, TEntity entity)
    {
        try
        {
            return await onSuccess();
        }
        catch(Exception e)
        {
            Trace.WriteLine(e);
            return entity;
        }
    }

    public async static Task<IResult<T>> FailValidationIfInvalidAsync<T>(this ValidationResult result,
        RequestHandlerDelegate<IResult<T>> onSuccess) =>
        result.IsValid ? await onSuccess() : ValidationResult<T>.Failed(result.Errors, 400);
}
