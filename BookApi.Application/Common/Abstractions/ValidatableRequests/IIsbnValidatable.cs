namespace Library.Application.Common.Abstractions.ValidatableRequests;

internal interface IIsbnValidatable : IValidatableRequest
{
    string Isbn { get; }
}
