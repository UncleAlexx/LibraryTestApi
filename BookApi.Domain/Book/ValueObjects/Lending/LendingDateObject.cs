namespace Library.Domain.Book.ValueObjects.Lending;

public sealed class LendingDateObject : DateObject<LendingDateObject>
{
    private LendingDateObject(in DateTime value, in bool success = true) : base(value, success) { }
 
    public override sealed Bounds<DateTime> Bounds { get; } = new(new(2000, 1, 1), DateTime.Today.AddDays(1));
    public static new string PropertyName { get; } = "LendingDate";
}