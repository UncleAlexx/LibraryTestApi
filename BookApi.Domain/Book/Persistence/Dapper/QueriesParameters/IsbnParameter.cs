namespace Library.Domain.Book.Persistence.Dapper.QueriesParameters;

internal sealed class IsbnParameter : QueryParameter<IsbnParameter, string>
{
    public string? Isbn { get => BackingField; set { BackingField = string.IsNullOrEmpty(value) ? BackingField : value; } }

    IsbnParameter() { }
}
