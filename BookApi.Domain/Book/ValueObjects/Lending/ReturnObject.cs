namespace Library.Domain.Book.ValueObjects.Lending;

public sealed record ReturnDateObject : ValueObject<DateTime, ReturnDateObject>
{
    private ReturnDateObject(DateTime value) : base(value) => Value = value;

    public static EntityResult<ReturnDateObject> Create(DateTime value) => 
        value >= BookPropertiesBounds.Return.Min && value <= BookPropertiesBounds.Return.Max? 
        EntityResult<ReturnDateObject>.Success(new(value)) :
        EntityResult<ReturnDateObject>.Failed(new(value));
}