namespace Library.Application.Common.Abstractions.ValidatableRequests;

public interface IIdValidatable : IValidatableRequest
{
    Guid Id { get; }
}
