﻿namespace Library.Infrastructure.Book.Persistence.Constants.Library;

internal class SqlQueries
{
    internal const string GetAll = """
        Select LendingDate, [Return] as ReturnDate, Isbn, Title, Genre, Description, Author, l.BookID, l.ID as LendingId, s.ID as StockId
        from Books.Lending l
        join  Books.Stock s
        on l.BookID = s.BookID;
        """;

    internal const string GetById = """
        Select LendingDate, [Return] as ReturnDate, Isbn, Title, Genre, Description, Author, l.BookID, l.ID as LendingId, s.ID as StockId
        from Books.Lending l
        join  Books.Stock s
        on l.BookID = s.BookID 
        where l.BookID = @Id 
        """;

    internal const string GetByIsbn = """
        Select LendingDate, [Return] as ReturnDate, Isbn, Title, Genre, Description, Author, l.BookID, l.ID as LendingId, s.ID as StockId
        from Books.Lending l
        join  Books.Stock s
        on s.BookID = l.BookID 
        where Isbn = @Isbn
        """;
    internal const string GetIdByIsbn = """
        select top (1) ID
        from Books.Books 
        where ID = (select top (1) BookID 
        from Books.Stock
        where Isbn = @Isbn)
    """;
    internal const string GetStockIdByIsbn = """
        select top (1) ID 
        from Books.Stock
        where Isbn = @Isbn
    """;
    internal const string GetLendingIdByIsbn = """
        select top (1) ID 
        from Books.Lending
        where BookID = (select top (1) BookID from Books.Stock where Isbn = @Isbn)
    """;
}
