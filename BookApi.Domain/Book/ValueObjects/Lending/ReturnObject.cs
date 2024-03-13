namespace Library.Domain.Book.ValueObjects.Lending;

public sealed class ReturnDateObject : DateObject<ReturnDateObject>
{
    private ReturnDateObject(in DateTime value, in bool success = true) : base(value, success) =>
        ErrorMessage = ValidationMessages.ReturnMessage;
    
    [JsonIgnore]
    public override sealed Bounds<DateTime> Bounds { get; } = new Bounds<DateTime>(new(2000, 1, 1), new(2099, 12, 31));
    [JsonIgnore]
    public override string ErrorMessage { get; init; }

    public static new string PropertyName { get; } = "ReturnDate";
}