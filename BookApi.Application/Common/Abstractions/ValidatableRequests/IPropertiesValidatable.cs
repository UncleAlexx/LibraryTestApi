namespace Library.Application.Common.Abstractions.ValidatableRequests;

public interface IBookValidatable : IValidatableRequest
{
    BookPoco Book { get; }
}
