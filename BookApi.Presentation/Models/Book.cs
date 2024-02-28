using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using BookApi.Domain.Book;
using Autoservice.Presentation;
using BookApi.Presentation.Models.Common.Extensions;
using BookApi.Presentation.Contracts.Book.Common;
using BookApi.Application.Book.Commands.Update;
using BookApi.Application.Book.Commands.Remove;
using BookApi.Application.Book.Commands.Add;
using BookApi.Application.Book.Queries.GetAll;
using BookApi.Application.Book.Queries.GetById;
using BookApi.Application.Book.Queries.GetByIsbn;
using BookApi.Presentation.Contracts.Book.Delete;
using BookApi.Presentation.Models.Common.Constants.Enums;
using BookApi.Presentation.Contracts.Book.Add;
using BookApi.Presentation.Contracts.Book.Common.Mappers;

namespace BookApi.Presentation.Models;

public static class BookModel
{
    private static readonly ushort[] _codes  = [404, 503];

    public static WebApplication AddBookCommands(this WebApplication app)
    {
        var (command, query) = app.ConfigureOpenApi(MainGroupNames.BookMainGroup);

        command.MapPatch("/Update", async Task<Results<Ok<UpdateResponse<Book>>, ValidationProblem, ProblemHttpResult>> 
            ([FromBody] BookToAddView book, ISender sender, IBookMapper mapper) =>
            await EntityEndpointsFactory.CreateRequest(sender, new Update(mapper.ToBookPoco(book)),
            x => new UpdateResponse<Book>(DateTime.Now, "/Update", x, x), TypedResults.Ok)).
            ConfigureDocumentation<ProblemHttpResult>(_codes);

        command.MapDelete("/Delete{isbn}", async Task<Results<Accepted<DeleteResponse<Book>>, ValidationProblem, ProblemHttpResult>> 
            (ISender sender, string isbn) => await EntityEndpointsFactory.CreateRequest(sender, new Remove(isbn), x => 
            new DeleteResponse<Book>(DateTime.Now, "/Delete{isbn}", x, x),TypedResults.Accepted, "")).
            ConfigureDocumentation<ProblemHttpResult>(_codes);

        command.MapPost("/Add", async Task<Results<Created<AddResponse<Book>>, ValidationProblem, ProblemHttpResult>> 
            ([FromBody] BookToAddView book, IBookMapper mapper, ISender sender) => 
            await EntityEndpointsFactory.CreateRequest(sender, new Add(mapper.ToBookPoco(book)), x => 
            new AddResponse<Book>(DateTime.Now, "/Add", x), TypedResults.Created, "")).
            ConfigureDocumentation<ProblemHttpResult>(_codes);

        query.MapGet("/GetAll", async Task<Results<Ok<EntitiesResponse<Book>>, ProblemHttpResult>> (ISender sender) => 
        await EntityEndpointsFactory.CreateRequest(sender, new GetAll(), x => new EntitiesResponse<Book>(DateTime.Now, "/GetAll", x),
        TypedResults.Ok)).ConfigureDocumentation<ProblemHttpResult>(_codes);

        query.MapGet("/GetById{bookId}", async Task<Results<Ok<EntityResponse<Book>>, ValidationProblem, ProblemHttpResult>> 
            (Guid bookId, ISender sender) => await EntityEndpointsFactory.CreateRequest(sender, new GetById(bookId),x => 
            new EntityResponse<Book>(DateTime.Now, "/GetById{bookId}", x), TypedResults.Ok)).ConfigureDocumentation<ProblemHttpResult>(_codes);

        query.MapGet("/GetByIsbn{isbn}", async Task<Results<Ok<EntityResponse<Book>>, ValidationProblem, ProblemHttpResult>> 
            (string isbn, ISender sender) => await EntityEndpointsFactory.CreateRequest(sender, new GetByIsbn(isbn), x =>
            new EntityResponse<Book>(DateTime.Now, "/GetByIsbn{isbn}", x), TypedResults.Ok)).ConfigureDocumentation<ProblemHttpResult>(_codes);

        command.RequireAuthorization("Admin");
        query.RequireAuthorization();
        return app;
    }
}
