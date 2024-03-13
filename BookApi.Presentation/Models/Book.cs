using BookApi.Presentation.Contracts.Book.Common;
using Library.Presentation.Contracts.Book.Common;

namespace Library.Presentation.Models;

internal static class BookModel
{
    private static readonly ushort[] _codes  = [404, 503];

    internal static WebApplication MapBook(this WebApplication app)
    {
        var (command, query) = app.ConfigureOpenApi(PrimaryGroups.BookMainGroup);

        command.MapPatch("/Update", async Task<Results<Ok<UpdateResponse<Book>>, ValidationProblem, ProblemHttpResult>> 
            ([FromBody] BookToChangeView book, ISender sender, IBookMapper mapper) =>
            await EntityEndpointsFactory.CreateRequest(sender, new Update(mapper.ToBookPoco(book)),
            book => new UpdateResponse<Book>(DateTime.Now, "/Update", book), TypedResults.Ok)).
            ConfigureDocumentation<ProblemHttpResult>(_codes);

        command.MapDelete("/Delete{isbn}", async Task<Results<Accepted<DeleteResponse<Book>>, ValidationProblem, ProblemHttpResult>> 
            (ISender sender, string isbn) => await EntityEndpointsFactory.CreateRequest(sender, new Remove(isbn), book => 
            new DeleteResponse<Book>(DateTime.Now, "/Delete{isbn}", book, book),TypedResults.Accepted, "")).
            ConfigureDocumentation<ProblemHttpResult>(_codes);

        command.MapPost("/Add", async Task<Results<Created<AddResponse<Book>>, ValidationProblem, ProblemHttpResult>> 
            ([FromBody] BookToChangeView book, IBookMapper mapper, ISender sender) => 
            await EntityEndpointsFactory.CreateRequest(sender, new Add(mapper.ToBookPoco(book)), x => 
            new AddResponse<Book>(DateTime.Now, "/Add", x), TypedResults.Created, "")).
            ConfigureDocumentation<ProblemHttpResult>(_codes);

        query.MapGet("/GetAll", async Task<Results<Ok<EntitiesResponse<Book>>, ProblemHttpResult>> (ISender sender, HttpRequest request) => 
        await EntityEndpointsFactory.CreateRequest(sender, new GetAll(), books => new EntitiesResponse<Book>(DateTime.Now, "/GetAll",
        books), TypedResults.Ok)).ConfigureDocumentation<EntitiesResponse<Book>>(_codes);

        query.MapGet("/GetById{bookId}", async Task<Results<Ok<EntityResponse<Book>>, ValidationProblem, ProblemHttpResult>> 
            (Guid bookId, ISender sender) => await EntityEndpointsFactory.CreateRequest(sender, new GetById(bookId), book => 
            new EntityResponse<Book>(DateTime.Now, "/GetById{bookId}", book), TypedResults.Ok)).
            ConfigureDocumentation<ProblemHttpResult>(_codes);

        query.MapGet("/GetByIsbn{isbn}", async Task<Results<Ok<EntityResponse<Book>>, ValidationProblem, ProblemHttpResult>> 
            (string isbn, ISender sender) => await EntityEndpointsFactory.CreateRequest(sender, new GetByIsbn(isbn), book =>
            new EntityResponse<Book>(DateTime.Now, "/GetByIsbn{isbn}", book), TypedResults.Ok)).
            ConfigureDocumentation<ProblemHttpResult>(_codes);

        //command.RequireAuthorization("Admin");
        //query.RequireAuthorization();
        return app;
    }
}
