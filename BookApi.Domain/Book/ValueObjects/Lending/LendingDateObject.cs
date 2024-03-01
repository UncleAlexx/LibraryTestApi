namespace Library.Domain.Book.ValueObjects.Lending;

public sealed record LendingDateObject : ValueObject<DateTime, LendingDateObject>
{
    private LendingDateObject(DateTime value) : base(value) => Value = value;

    public static EntityResult<LendingDateObject> Create(DateTime value) => 
        value.IsUpToDate()? EntityResult<LendingDateObject>.Success(new(value)) : 
        EntityResult<LendingDateObject>.Failed(new(value));
}