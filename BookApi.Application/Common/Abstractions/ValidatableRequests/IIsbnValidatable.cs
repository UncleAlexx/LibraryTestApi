namespace BookApi.Application.Common.Abstractions.ValidatableRequests;

public interface IIsbnValidatable : IValidatableRequest
{
    string Isbn { get; }
}
