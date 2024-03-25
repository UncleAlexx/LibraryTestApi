namespace Library.Domain.Book.ValueObjects.Stock;

public sealed partial class GenreObject : StringObject<GenreObject>
{
    private GenreObject(in string value, in bool success = true) : base(value, success) { }

    public override string ErrorMessage { get; init; } = ValidationMessages.GenreMessage;
    [JsonIgnore]
    public override sealed bool Default { get; } = true;
    [JsonIgnore] 
    public override sealed Bounds<int> Bounds { get; } = new Bounds<int>(5, 30); 
    public static new string PropertyName { get; } = "Genre";

    [GeneratedRegex(@"^(?i)((?<Cyryllic>[а-яё])|(?<Latin>[a-z])){5,}$")]
    public override sealed partial Regex Pattern();
}