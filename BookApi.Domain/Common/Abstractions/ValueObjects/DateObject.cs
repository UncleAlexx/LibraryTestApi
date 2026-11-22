namespace Library.Domain.Common.Abstractions.ValueObjects;

public abstract class DateObject<TDateObject>(in DateTime value, in bool success = true) : 
    ValueObject<DateTime, TDateObject, EntityResult<TDateObject>>(value, success),
    IDateObject<EntityResult<TDateObject>> where TDateObject : DateObject<TDateObject>
{
    public abstract Bounds<DateTime> Bounds { get; }

    protected static new EntityResult<TDateObject> CreateBase(in DateTime value)
    {
        var inst = TInstance(value);
        return inst.Bounds.InRange(value) ? EntityResult<TDateObject>.Success(inst) : 
            EntityResult<TDateObject>.Failed(inst);
    }
}