using BookApi.Domain.Common.Models;
using BookApi.Domain.Common.Results.ResultsKind;

namespace BookApi.Domain.Book.ValueObjects.Stock;

public record AuthorObject : ValueObject<string, AuthorObject>
{
    private AuthorObject(string value) : base(value) => Value = value;

    public static EntityResult<AuthorObject> Create(string value) =>
        value is not null or "" && BookPropertiesNames.Author.IsMatch(value!) ?
        EntityResult<AuthorObject>.Success(new(value)) : EntityResult<AuthorObject>.Failed(new(value));
}