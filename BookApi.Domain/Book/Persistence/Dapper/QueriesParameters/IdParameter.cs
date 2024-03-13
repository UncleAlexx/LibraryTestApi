namespace Library.Domain.Book.Persistence.Dapper.QueriesParameters;

internal sealed class IdParameter : QueryParameter<IdParameter, Guid>
{
    public Guid Id { get => BackingField; set  { BackingField = value == Guid.Empty ? BackingField : value; } }

    IdParameter() { }
}
