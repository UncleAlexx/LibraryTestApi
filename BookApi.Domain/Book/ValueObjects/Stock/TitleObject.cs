namespace Library.Domain.Book.ValueObjects.Stock;

public sealed partial class TitleObject : StringObject<TitleObject>
{
    private TitleObject(in string value, in bool success = true) : base(value, success) { }

    [JsonIgnore]
    public override sealed string ErrorMessage { get; init; } = ValidationMessages.TitleMessage;
    [JsonIgnore]
    public override sealed Bounds<int> Bounds { get; } = new Bounds<int>(3, 30); 
    public static new string PropertyName { get; } = "Title";

    [GeneratedRegex(@"^(?i)((?<Cyryllic>[а-яё])|(?<Latin>[a-z])){1,}( ){0,1}((?<Cyryllic>[а-яё])|(?<Latin>[a-z])){2,}$")]
    public override sealed partial Regex Pattern();
}