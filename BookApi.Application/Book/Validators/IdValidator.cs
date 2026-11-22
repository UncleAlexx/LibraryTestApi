namespace Library.Application.Book.Validators;

internal sealed class IdObjectValidator : AbstractValidator<IdObject>
{
    public IdObjectValidator() => RuleFor(x => x).IsNotNullOrEmpty<IdObject, IdObject, Guid>(IdObject.PropertyName);
}
