namespace Library.Domain.Book.ValueObjects.Stock;

public sealed record IsbnObject : ValueObject<string, IsbnObject>
{
    private IsbnObject(string value) : base(value) => Value = value;

    public static  EntityResult<IsbnObject> Create(string value) =>
        value is not null or "" && BookPropertiesNames.Isbn.IsMatch(value!) ?
        EntityResult<IsbnObject>.Success(new(value)) : EntityResult<IsbnObject>.Failed(new(value));
}