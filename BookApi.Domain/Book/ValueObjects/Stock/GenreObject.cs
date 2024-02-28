using BookApi.Domain.Book.Validation;
using BookApi.Domain.Common.Models;
using BookApi.Domain.Common.Results.ResultsKind;
using System.Runtime.CompilerServices;

namespace BookApi.Domain.Book.ValueObjects.Stock;


public record GenreObject : ValueObject<string, GenreObject>
{
    private GenreObject(string value) : base(value) => Value = value;

    public static EntityResult<GenreObject> Create(string value) =>
        value is not null or "" && BookPropertiesNames.Genre.IsMatch(value!) ?
        EntityResult<GenreObject>.Success(new(value)) : EntityResult<GenreObject>.Failed(new(value));

}