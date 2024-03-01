namespace Library.Domain.Book.ValueObjects.Stock;

public sealed record TitleObject : ValueObject<string, TitleObject>
{
    private TitleObject(string value) : base(value) => Value = value;

    public static EntityResult<TitleObject> Create(string value) =>
        value is not null or "" && BookPropertiesNames.Title.IsMatch(value!) ?
        EntityResult<TitleObject>.Success(new(value)) : EntityResult<TitleObject>.Failed(new(value));
}