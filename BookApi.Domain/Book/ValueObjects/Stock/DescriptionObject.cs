using BookApi.Domain.Book.Validation;
using BookApi.Domain.Book.Validation.Enums;
using BookApi.Domain.Book.Validation.Extensions;
using BookApi.Domain.Common.Models;
using BookApi.Domain.Common.Results.ResultsKind;

namespace BookApi.Domain.Book.ValueObjects.Stock;

public record DescriptionObject : ValueObject<string, DescriptionObject>
{
    private DescriptionObject(string value) : base(value) => Value = value;

    public static EntityResult<DescriptionObject> Create(string value) =>
        value is not null or "" && BookPropertiesNames.Description.IsMatch(value!) ?
        EntityResult<DescriptionObject>.Success(new(value)) : EntityResult<DescriptionObject>.Failed(new(value));
}
