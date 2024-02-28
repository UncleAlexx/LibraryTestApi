using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApi.Presentation.Contracts.Book.Common.Bases;

internal abstract record ResponseBase<T>(DateTime Date, string Route, ushort Code = 200);

