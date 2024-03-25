namespace Library.Presentation.Endpoints;

internal static class Book
{
    private static readonly ushort[] _codes  = [404, 503];

    internal static WebApplication MapBook(this WebApplication app)
    {
        var mainGroup = app.ConfigureGroups(SecondaryGroups.Book);

        mainGroup.MapPatch("/", async Task<Results<Ok<UpdateResponse<BookEntity>>, ValidationProblem,
            ProblemHttpResult>> ([FromBody] BookToChangeView book, ISender sender, IBookMapper mapper,
            HttpRequest request) => await EntityEndpointsFactory.CreateRequest(sender, new Update(mapper.ToBookPoco(book)),
            book => new UpdateResponse<BookEntity>(DateTime.Now, request.Path, book), TypedResults.Ok)).RequireAuthorization("Admin").
            ConfigureDocumentation<ProblemHttpResult>(_codes);

        mainGroup.MapDelete("/{isbn}", async Task<Results<Accepted<DeleteResponse<BookEntity>>, ValidationProblem,
            ProblemHttpResult>> (ISender sender, string isbn, HttpRequest request) => 
            await EntityEndpointsFactory.CreateRequest
            (sender, new Remove(isbn), book => new DeleteResponse<BookEntity>(DateTime.Now, request.Path, 
            book), TypedResults.Accepted, request.Path)).RequireAuthorization("Admin").ConfigureDocumentation<ProblemHttpResult>(_codes);

        mainGroup.MapPost("", async Task<Results<Created<AddResponse<BookEntity>>, ValidationProblem, 
            ProblemHttpResult>>([FromBody] BookToChangeView book, IBookMapper mapper, ISender sender, 
            HttpRequest request) => await EntityEndpointsFactory.CreateRequest(sender, new Add(mapper.ToBookPoco(book)),
            book => new AddResponse<BookEntity>(DateTime.Now, request.Path, book), TypedResults.Created, request.Path)).
            RequireAuthorization("Admin").ConfigureDocumentation<ProblemHttpResult>(_codes);

        mainGroup.MapGet("", async Task<Results<Ok<EntitiesResponse<BookEntity>>, ProblemHttpResult>> 
            (ISender sender, HttpRequest request) => await EntityEndpointsFactory.CreateRequest(sender, new GetAll(),
            books => new EntitiesResponse<BookEntity>(DateTime.Now, request.Path,
            books), TypedResults.Ok)).RequireAuthorization().ConfigureDocumentation<EntitiesResponse<BookEntity>>(_codes);

        mainGroup.MapGet("/{id}", async Task<Results<Ok<EntityResponse<BookEntity>>, ValidationProblem, 
            ProblemHttpResult>> (Guid id, ISender sender, HttpRequest request) => 
            await EntityEndpointsFactory.CreateRequest(sender, new GetById(id), book => 
            new EntityResponse<BookEntity>(DateTime.Now, request.Path, book), TypedResults.Ok)).
            RequireAuthorization().ConfigureDocumentation<ProblemHttpResult>(_codes);

        mainGroup.MapGet("/{isbn:regex(^[0-9-]+$)}", async Task<Results<Ok<EntityResponse<BookEntity>>, ValidationProblem, 
            ProblemHttpResult>> (string isbn, ISender sender, HttpRequest request) => await EntityEndpointsFactory.
            CreateRequest(sender, new GetByIsbn(isbn), book => new EntityResponse<BookEntity>(DateTime.Now, 
            request.Path, book), TypedResults.Ok)).RequireAuthorization().ConfigureDocumentation<ProblemHttpResult>(_codes);
        return app;
    }
}
