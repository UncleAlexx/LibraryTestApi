namespace BookApi.Domain.Common.Errors.Bases;

public interface IError
{
    internal string? Message { get; init; }
}
