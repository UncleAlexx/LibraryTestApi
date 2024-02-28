using BookApi.Domain.Common.Persistence.Dapper.Abstractions;

namespace BookApi.Domain.Book.Persistence.Dapper.QueriesParameters;

public sealed class IsbnParameter : QueryParameter<IsbnParameter>
{
    public string? Isbn { get; set; }

    IsbnParameter() { }
}
