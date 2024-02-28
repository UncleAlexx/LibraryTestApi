using BookApi.Domain.Book.Validation;
using BookApi.Domain.Common.Models;
using BookApi.Domain.Common.Results.ResultsKind;

namespace BookApi.Domain.Book.ValueObjects.Stock;


public record TitleObject : ValueObject<string, TitleObject>
{
    private TitleObject(string value) : base(value) => Value = value;

    public static EntityResult<TitleObject> Create(string value) =>
        value is not null or "" && BookPropertiesNames.Title.IsMatch(value!) ?
        EntityResult<TitleObject>.Success(new(value)) : EntityResult<TitleObject>.Failed(new(value));
}