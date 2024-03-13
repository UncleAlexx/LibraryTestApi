namespace Library.Domain.Common.Abstractions.ValueObjects;

public abstract class DateObject<TDateObject> : ValueObject<DateTime, TDateObject, EntityResult<TDateObject>>,
    IDateObject<EntityResult<TDateObject>> where TDateObject : DateObject<TDateObject>
{
    protected DateObject(in DateTime value, in bool success = true) : base(value, success) { }

    [JsonIgnore]
    public override string ErrorMessage { get; init; } = "";
    [JsonIgnore]    
    public abstract Bounds<DateTime> Bounds { get; }

    protected static new EntityResult<TDateObject> CreateBase(in DateTime value)
    {
        var inst = TInstance(value);
        return inst.Bounds.InRange(value) ? EntityResult<TDateObject>.Success(inst) : 
            EntityResult<TDateObject>.Failed(TInstance(value, false));
    }
}