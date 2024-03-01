namespace Library.Domain.Book.ValueObjects.Stock;

public sealed record DescriptionObject : ValueObject<string, DescriptionObject>
{
    private DescriptionObject(string value) : base(value) => Value = value;

    public static EntityResult<DescriptionObject> Create(string value) =>
        value is not null or "" && BookPropertiesNames.Description.IsMatch(value!) ?
        EntityResult<DescriptionObject>.Success(new(value)) : EntityResult<DescriptionObject>.Failed(new(value));
}
