namespace Library.Domain.Book.Entities;

public sealed class Lending : Entity<IdObject> 
{
    [SetsRequiredMembers]
    private Lending(LendingDateObject lendingDate, ReturnDateObject @return, IdObject id, BookIdObject bookId) :
        base(id) => (LendingDate, Return, BookId) = (lendingDate, @return, bookId);

    [JsonIgnore]
    public Book? Book { get; set; }

    public required BookIdObject BookId { get; set; }

    public required LendingDateObject LendingDate { get; set; }

    public required ReturnDateObject Return { get; set; }
    
    public static EntityResult<Lending> CreateWithValidation(DateTime lendingDate, DateTime returnDate, Guid bookId,
        Guid id)
    {
        var strongLendingDate = LendingDateObject.Create(lendingDate);
        var strongReturnDate = ReturnDateObject.Create(returnDate);
        Lending lending = new(strongLendingDate.Entity, strongReturnDate.Entity, IdObject.Create(id), 
            BookIdObject.Create(bookId));
        if (strongLendingDate.Successful && strongReturnDate.Successful && 
            strongLendingDate.Entity.Value < strongReturnDate.Entity.Value)
            return EntityResult<Lending>.Success(lending);
        return EntityResult<Lending>.Failed(lending);
    }
}
