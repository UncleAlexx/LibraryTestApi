namespace Library.Domain.Book.ValueObjects.Lending;

public sealed class ReturnDateObject : DateObject<ReturnDateObject>
{
    private ReturnDateObject(in DateTime value, in bool success) : base(value, success) =>
        ErrorMessage = ValidationMessages.ReturnMessage; 

    [JsonIgnore]
    public override string ErrorMessage { get; init; } = ValidationMessages.ReturnMessage;
    [JsonIgnore]
    public override sealed Bounds<DateTime> Bounds { get; } = new Bounds<DateTime>(new(2000, 1, 1), new(2099, 12, 31));
    public static new string PropertyName { get; } = "ReturnDate";
}