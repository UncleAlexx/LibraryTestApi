using BookApi.Domain.Book.Validation.Constants;
using BookApi.Domain.Common.Models;
using BookApi.Domain.Common.Results.ResultsKind;

namespace BookApi.Domain.Book.ValueObjects.Return;

public record ReturnDateObject : ValueObject<DateTime, ReturnDateObject>
{
    private ReturnDateObject(DateTime value) : base(value) => Value = value;

    public static EntityResult<ReturnDateObject> Create(DateTime value) => 
        value >= BookPropertiesBounds.Return.Min && value <= BookPropertiesBounds.Return.Max? 
        EntityResult<ReturnDateObject>.Success(new(value)) :
        EntityResult<ReturnDateObject>.Failed(new(value));
}