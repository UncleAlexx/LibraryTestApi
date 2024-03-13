using Library.Domain.Common.Abstractions.ValueObjects.Constants;

namespace Library.Application.Book.Validators;

internal sealed class PropertiesValidator : AbstractValidator<BookView>
{
    public PropertiesValidator()
    {
        RuleFor(book => book.Stock!.Isbn).NotNullOrEmpty<BookView, IsbnObject, string>(IsbnObject.PropertyName).IsNullOrLengthInBounds
            (IsbnObject.PropertyName).MatchesSubpatternsOrIsNull(IsbnObject.PropertyName);
        RuleFor(book => book.Stock!.Author).NotNullOrEmpty<BookView, AuthorObject, string>(AuthorObject.PropertyName).IsNullOrLengthInBounds
            (AuthorObject.PropertyName).MatchesSubpatternsOrIsNull(AuthorObject.PropertyName);
        RuleFor(book => book.Stock!.Title).NotNullOrEmpty<BookView, TitleObject, string>(TitleObject.PropertyName).IsNullOrLengthInBounds
            (TitleObject.PropertyName).MatchesSubpatternsOrIsNull(TitleObject.PropertyName);
        RuleFor(book => book.Stock!.Description!).MatchesSubpatternsOrIsNull(DescriptionObject.PropertyName).
            IsNullOrLengthInBounds(DescriptionObject.PropertyName);
        RuleFor(book => book.Stock!.Genre!).MatchesSubpatternsOrIsNull(GenreObject.PropertyName).IsNullOrLengthInBounds(GenreObject.PropertyName);
        RuleFor(book => book.Lending!.LendingDate).NotNullOrEmpty<BookView, LendingDateObject, DateTime>(LendingDateObject.PropertyName).IsNullOrLengthInBounds2(LendingDateObject.PropertyName);
        RuleFor(book => book.Lending!.Return).NotNullOrEmpty<BookView, ReturnDateObject, DateTime>(ReturnDateObject.PropertyName).IsNullOrLengthInBounds2(ReturnDateObject.PropertyName);
        RuleFor(book => book.Lending).Must(x => x.AreDatesValid()).WithMessage(x => x.Lending.Return.ErrorMessage).OverridePropertyName("ReturnDate");
    }
}
