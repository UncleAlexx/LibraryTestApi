namespace BookApi.Application.BookModel.Validators;

internal sealed class IdObjectValidator : AbstractValidator<IdObject>
{
    public IdObjectValidator() => RuleFor(x => x.Value).NotNullOrEmpty().WithName(PropertiesConstants.RawId);
}
