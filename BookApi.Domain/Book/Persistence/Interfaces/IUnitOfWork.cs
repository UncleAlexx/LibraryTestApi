using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApi.Domain.Book.Persistence.Interfaces;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}
