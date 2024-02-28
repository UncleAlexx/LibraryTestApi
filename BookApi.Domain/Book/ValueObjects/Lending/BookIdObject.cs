using BookApi.Domain.Common.Models;
using BookApi.Domain.Common.Results.Common;
using BookApi.Domain.Common.Results.ResultsKind;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace BookApi.Domain.Book.ValueObjects.Lending;

public record BookIdObject : ValueObject<Guid, BookIdObject>
{
    private BookIdObject(Guid value) : base(value) => Value = value;

    public static BookIdObject Create(Guid value) => new(value);

    public static BookIdObject CreateUnique() => new(Guid.NewGuid());
}