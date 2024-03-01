namespace Library.Domain.Book.ValueObjects.Stock;

public sealed record GenreObject : ValueObject<string, GenreObject>
{
    private GenreObject(string value) : base(value) => Value = value;

    public static EntityResult<GenreObject> Create(string value) =>
        value is not null or "" && BookPropertiesNames.Genre.IsMatch(value!) ?
        EntityResult<GenreObject>.Success(new(value)) : EntityResult<GenreObject>.Failed(new(value));

}