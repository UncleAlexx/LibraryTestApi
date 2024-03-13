namespace Library.Application.Book.Validators;

internal sealed class IdObjectValidator : AbstractValidator<IdObject>
{
    public IdObjectValidator() => RuleFor(x => x).NotNullOrEmpty1<IdObject, IdObject, Guid>(IdObject.PropertyName);
}
