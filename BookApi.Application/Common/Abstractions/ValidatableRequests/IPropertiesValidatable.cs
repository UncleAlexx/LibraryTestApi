namespace Library.Application.Common.Abstractions.ValidatableRequests;

internal interface IBookValidatable : IValidatableRequest
{
    BookPoco Book { get; }
}
