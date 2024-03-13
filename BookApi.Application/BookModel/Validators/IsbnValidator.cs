namespace Library.Application.Book.Validators;

internal sealed class IsbnValidator : AbstractValidator<IsbnObject>
{
    public IsbnValidator() => RuleFor(x => x).NotNullOrEmpty<IsbnObject, IsbnObject, string>(IsbnObject.PropertyName).IsNullOrLengthInBounds(IsbnObject.PropertyName).
        MatchesSubpatternsOrIsNull(IsbnObject.PropertyName);
}
