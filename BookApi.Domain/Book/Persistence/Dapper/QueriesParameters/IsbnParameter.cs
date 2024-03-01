namespace Library.Domain.Book.Persistence.Dapper.QueriesParameters;

public sealed class IsbnParameter : QueryParameter<IsbnParameter>
{
    public string? Isbn { get; set; }

    IsbnParameter() { }
}
