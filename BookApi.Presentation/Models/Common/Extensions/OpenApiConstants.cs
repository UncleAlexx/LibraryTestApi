using BookApi.Domain.Book;

namespace BookApi.Presentation.Models.Common.Extensions;

internal static class OpenApiConstants
{
    public const string BookModelMainGroup = nameof(Book);
    public const string QueriesSubGroup = "Queries";
    public const string CommandsSubGroup = "Commands";
}