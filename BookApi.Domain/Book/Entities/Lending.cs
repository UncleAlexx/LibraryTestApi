namespace Library.Domain.Book.Entities;

public sealed class Lending : Entity<IdObject>
{
    [SetsRequiredMembers]
    private Lending(LendingDateObject lendingDate, ReturnDateObject @return, IdObject id, BookIdObject bookId) :
        base(id) => (LendingDate, Return, BookId) = (lendingDate, @return, bookId);

    [JsonIgnore]
    public Book? Book { get; private set; }
    public BookIdObject BookId { get; private set; }

    public required LendingDateObject LendingDate { get; set; }
    public required ReturnDateObject Return { get; set; }

    public bool AreDatesValid()
    { 
        if (this is { Return: null } or { LendingDate: null })
            return false;
        return LendingDate.Value < Return.Value;
    }
    
    public static EntityResult<Lending> Create(in EntityResult<LendingDateObject> lendingDate, 
        in EntityResult<ReturnDateObject> returnDate, in BookIdObject bookId, in IdObject id)
    {
        Lending lending = new(lendingDate.Entity, returnDate.Entity, id, bookId);
        if (lendingDate.Successful && returnDate.Successful && lending.AreDatesValid())
            return EntityResult<Lending>.Success(lending);
        return EntityResult<Lending>.Failed(lending);
    }
}
