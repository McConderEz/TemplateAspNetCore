using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.SharedKernel.Shared;

namespace Template.Domain.DomainEvents
{
    public sealed record BookTakenDomainEvent(Guid LibrarianId, Guid BookId)
        : IDomainEvent
    {
    }
}
