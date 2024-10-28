using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.Repositories;
using Template.Domain.DomainEvents;

namespace Template.Application.BookManagement.Events
{
    internal sealed class BookTakenDomainEventHandler
        : INotificationHandler<BookTakenDomainEvent>
    {
        //TODO: Сделать EmailService
        

        public async Task Handle(
            BookTakenDomainEvent notification, CancellationToken cancellationToken = default)
        {
            
        }
    }
}
