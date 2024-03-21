namespace Library.Domain.Book.ValueObjects.Stock;

public sealed partial class IsbnObject : StringObject<IsbnObject>
{
    private IsbnObject(in string value, in bool success) : base(value, success) 
        => ErrorMessage = ValidationMessages.IsbnMessage;

    public override Bounds<int> Bounds { get; } = new(17, 17);
    public override string ErrorMessage { get; init; }
    public static new string PropertyName { get; } = "Isbn";

    [GeneratedRegex(@"^\d{3}-\d-\d{2}-\d{6}-\d$")]
    public override sealed partial Regex Pattern();
}