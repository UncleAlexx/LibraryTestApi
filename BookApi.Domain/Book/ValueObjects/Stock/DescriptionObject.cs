namespace Library.Domain.Book.ValueObjects.Stock;

public sealed partial class DescriptionObject : StringObject<DescriptionObject>
{
    private DescriptionObject(in string value, in bool success = true) : base(value, success) { }

    public override sealed Bounds<int> Bounds { get; } = new Bounds<int>(20, 100); 
    public override sealed bool Default { get; } = true; 
    public override string ErrorMessage { get; init; } = ValidationMessages.DescriptionMessage;
    public static new string PropertyName { get; } = "Description";


    [GeneratedRegex(@"^(?i)(((?<Cyryllic>[а-яё])|(?<Latin>[a-z])){1,}( ){0,1})+((?<Cyryllic>[а-яё])|(?<Latin>[a-z])){2,}$")]
    public override sealed partial Regex Pattern();
}
