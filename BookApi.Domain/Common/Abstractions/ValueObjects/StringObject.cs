namespace Library.Domain.Common.Abstractions.ValueObjects;

public abstract class StringObject<TStringObject>(in string value, in bool success) : 
    ValueObject<string, TStringObject, EntityResult<TStringObject>>(value, success),
    IStringObject<EntityResult<TStringObject>> where TStringObject : StringObject<TStringObject>
{
    public abstract Bounds<int> Bounds { get; }
    [JsonIgnore]
    public virtual bool Default { get; } = false;
    
    public abstract Regex Pattern();

    public bool IsMatch() 
    {
        var match = this switch
        {
            { Default: true, Value: null } => null,
            { Value: not null } => Pattern().Match(Value),
            _ => Match.Empty
        };
        static bool IsLanguageUnique(Match match) =>
            (match.Groups[RegexNamedGroups.Cyryllic].Success &&
            match.Groups[RegexNamedGroups.Latin].Success) is false;
        return match is null || match.Success && 
            (match.Groups.ContainsKey(RegexNamedGroups.Cyryllic) is false || IsLanguageUnique(match));
    }

    protected private static new EntityResult<TStringObject> CreateBase(in string value)
    {
        var success = TInstance(value);
        return success.IsMatch() && (success.Default && success.Value is null || 
            success.Bounds.InRange(value.Length)) ? EntityResult<TStringObject>.Success(success) : 
            EntityResult<TStringObject>.Failed(TInstance(value!, optionalArg: false));
    }
}

file static class RegexNamedGroups
{
    public const string Cyryllic = "Cyryllic";
    public const string Latin = "Latin";
}