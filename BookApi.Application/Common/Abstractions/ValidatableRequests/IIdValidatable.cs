namespace Library.Application.Common.Abstractions.ValidatableRequests;

internal interface IIdValidatable : IValidatableRequest
{
    Guid Id { get; }
}
