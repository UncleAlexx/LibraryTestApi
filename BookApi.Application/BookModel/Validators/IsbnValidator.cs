namespace Library.Application.Book.Validators;

internal sealed class IsbnValidator : AbstractValidator<IsbnObject>
{
    public IsbnValidator() => RuleFor(x => x.Value).NotNullOrEmpty().IsNullOrLengthInBounds(BookPropertiesNames.Isbn).
        MatchesSubpatternsOrIsNull(BookPropertiesNames.Isbn).
        WithName(PropertiesConstants.RawIsbn);
}
