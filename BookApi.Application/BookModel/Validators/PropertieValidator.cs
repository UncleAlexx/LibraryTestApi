namespace Library.Application.Book.Validators;

internal sealed class PropertiesValidator : AbstractValidator<BookView>
{
    public PropertiesValidator()
    {
        RuleFor(book => book.Stock.Isbn.Value).NotNullOrEmpty().IsNullOrLengthInBounds(BookPropertiesNames.Isbn).MatchesSubpatternsOrIsNull(BookPropertiesNames.Isbn);
        RuleFor(book => book.Stock.Author.Value).NotNullOrEmpty().IsNullOrLengthInBounds(BookPropertiesNames.Author).MatchesSubpatternsOrIsNull(BookPropertiesNames.Author);
        RuleFor(book => book.Stock.Title.Value).NotNullOrEmpty().IsNullOrLengthInBounds(BookPropertiesNames.Title).MatchesSubpatternsOrIsNull(BookPropertiesNames.Title);
        RuleFor(book => book.Stock.Description.Value).MatchesSubpatternsOrIsNull(BookPropertiesNames.Description).IsNullOrLengthInBounds(BookPropertiesNames.Description);
        RuleFor(book => book.Stock.Genre.Value).MatchesSubpatternsOrIsNull(BookPropertiesNames.Genre).IsNullOrLengthInBounds(BookPropertiesNames.Description);
        RuleFor(book => book.Lending.LendingDate.Value).NotNullOrEmpty().MatchesPredicate(BookPropertiesNames.Lending, PredicatesFactory.IsUpToDate);
        RuleFor(book => book.Lending.Return.Value).NotNullOrEmpty();
        RuleFor(book => book).MatchesPredicate(BookPropertiesNames.Return, PredicatesFactory.EnsureLesser, book => book.Lending.LendingDate.Value, book => book.Lending.Return.Value).
            WithName(PropertiesConstants.RawReturn);
    }
}
