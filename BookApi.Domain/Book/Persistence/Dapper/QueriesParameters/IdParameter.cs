using BookApi.Domain.Common.Persistence.Dapper.Abstractions;

namespace BookApi.Domain.Book.Persistence.Dapper.QueriesParameters;

public sealed class IdParameter : QueryParameter<IdParameter>
{
    public Guid? Id { get; set; }

    IdParameter() { }
}
