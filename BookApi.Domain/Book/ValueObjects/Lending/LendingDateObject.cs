using BookApi.Domain.Common.Models;
using BookApi.Domain.Common.Results.ResultsKind;

namespace BookApi.Domain.Book.ValueObjects.Lending;

public record LendingDateObject : ValueObject<DateTime, LendingDateObject>
{
    private LendingDateObject(DateTime value) : base(value) => Value = value;

    public static EntityResult<LendingDateObject> Create(DateTime value) => 
        value.IsUpToDate()? EntityResult<LendingDateObject>.Success(new(value)) : 
        EntityResult<LendingDateObject>.Failed(new(value));
}