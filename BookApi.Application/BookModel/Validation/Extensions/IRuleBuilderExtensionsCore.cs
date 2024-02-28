namespace BookApi.Application.Validators.Extensions.Book;

internal static partial class IRuleBuilderExtensions
{
    private static IRuleBuilderOptions<T, TProperty> WithPropertyMessage<T, TProperty>(this IRuleBuilderOptions<T, TProperty> builder, BookPropertiesNames property)
        => builder.WithMessage(tProperty => property.BuildBookMessage()); 
    
    private static readonly ReadOnlyDictionary<BookPropertiesNames, Bounds<int>> BookPropertiesBounds = new(
       new Dictionary<BookPropertiesNames, Bounds<int>>(Enum.GetValues<BookPropertiesNames>().Length)
       {
           [BookPropertiesNames.Isbn] = Domain.Book.Validation.Constants.BookPropertiesBounds.Isbn,
           [BookPropertiesNames.Title] = Domain.Book.Validation.Constants.BookPropertiesBounds.Title,
           [BookPropertiesNames.Genre] = Domain.Book.Validation.Constants.BookPropertiesBounds.Genre,
           [BookPropertiesNames.Author] = Domain.Book.Validation.Constants.BookPropertiesBounds.Author,
           [BookPropertiesNames.Description] = Domain.Book.Validation.Constants.BookPropertiesBounds.Description
       });
}
