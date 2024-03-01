namespace Library.Application.Common.Abstractions.ValidatableRequests;

public interface IIsbnValidatable : IValidatableRequest
{
    string Isbn { get; }
}
