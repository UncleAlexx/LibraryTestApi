using BookApi.Domain.Book.Validation;
using BookApi.Domain.Book.Validation.Enums;
using BookApi.Domain.Book.Validation.Extensions;
using BookApi.Domain.Common.Models;
using BookApi.Domain.Common.Results.ResultsKind;

namespace BookApi.Domain.Book.ValueObjects.Stock;


public record IsbnObject : ValueObject<string, IsbnObject>
{
    private IsbnObject(string value) : base(value) => Value = value;

    public static  EntityResult<IsbnObject> Create(string value) =>
        value is not null or "" && BookPropertiesNames.Isbn.IsMatch(value!) ?
        EntityResult<IsbnObject>.Success(new(value)) : EntityResult<IsbnObject>.Failed(new(value));
}