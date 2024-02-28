using BookApi.Infrastructure.Common;
using Microsoft.Extensions.Configuration;

namespace BookApi.Infrastructure.Book.Persistence.Constants.Common;

internal static class SqlParameters
{
    private const string LibraryConnectionStringKey = "LibraryConnectionString";

    /// <summary>
    /// should call  ConnectionStringConfigDecorator.Config To initialize
    /// </summary>
    internal readonly static string? LibraryConnectionString;

    static SqlParameters() => LibraryConnectionString = ConfigDecorator.Config?.GetConnectionString(LibraryConnectionStringKey) ?? "";
}
