namespace Library.Presentation.Endpoints;

internal static class Book
{
    private static readonly ushort[] _codes  = [404, 503];

    internal static WebApplication MapBook(this WebApplication app)
    {
        var (command, query) = app.ConfigureOpenApi(PrimaryGroups.BookMainGroup);

        command.MapPatch("/Update", async Task<Results<Ok<UpdateResponse<BookEntity>>, ValidationProblem,
            ProblemHttpResult>> ([FromBody] BookToChangeView book, ISender sender, IBookMapper mapper) =>
            await EntityEndpointsFactory.CreateRequest(sender, new Update(mapper.ToBookPoco(book)),
            book => new UpdateResponse<BookEntity>(DateTime.Now, "/Update", book), TypedResults.Ok)).
            ConfigureDocumentation<ProblemHttpResult>(_codes);

        command.MapDelete("/Delete{isbn}", async Task<Results<Accepted<DeleteResponse<BookEntity>>, ValidationProblem,
            ProblemHttpResult>> (ISender sender, string isbn) => await EntityEndpointsFactory.CreateRequest
            (sender, new Remove(isbn), book => new DeleteResponse<BookEntity>(DateTime.Now, "/Delete{isbn}", 
            book, book), TypedResults.Accepted, $"/Delete{isbn}")).ConfigureDocumentation<ProblemHttpResult>(_codes);

        command.MapPost("/Add", async Task<Results<Created<AddResponse<BookEntity>>, ValidationProblem, 
            ProblemHttpResult>>([FromBody] BookToChangeView book, IBookMapper mapper, ISender sender) => 
            await EntityEndpointsFactory.CreateRequest(sender, new Add(mapper.ToBookPoco(book)), book => 
            new AddResponse<BookEntity>(DateTime.Now, "/Add", book), TypedResults.Created, "")).
            ConfigureDocumentation<ProblemHttpResult>(_codes);

        query.MapGet("/GetAll", async Task<Results<Ok<EntitiesResponse<BookEntity>>, ProblemHttpResult>> 
            (ISender sender, HttpRequest request) => await EntityEndpointsFactory.CreateRequest(sender, new GetAll(),
            books => new EntitiesResponse<BookEntity>(DateTime.Now, "/GetAll",
            books), TypedResults.Ok)).ConfigureDocumentation<EntitiesResponse<BookEntity>>(_codes);

        query.MapGet("/GetById{bookId}", async Task<Results<Ok<EntityResponse<BookEntity>>, ValidationProblem, 
            ProblemHttpResult>> (Guid bookId, ISender sender) => 
            await EntityEndpointsFactory.CreateRequest(sender, new GetById(bookId), book => 
            new EntityResponse<BookEntity>(DateTime.Now, $"/GetById{bookId}", book), TypedResults.Ok)).
            ConfigureDocumentation<ProblemHttpResult>(_codes);

        query.MapGet("/GetByIsbn{isbn}", async Task<Results<Ok<EntityResponse<BookEntity>>, ValidationProblem, 
            ProblemHttpResult>> (string isbn, ISender sender) => await EntityEndpointsFactory.
            CreateRequest(sender, new GetByIsbn(isbn), book => new EntityResponse<BookEntity>(DateTime.Now, 
            $"/GetByIsbn{isbn}", book), TypedResults.Ok)).ConfigureDocumentation<ProblemHttpResult>(_codes);

        command.RequireAuthorization("Admin");
        query.RequireAuthorization();
        return app;
    }
}
