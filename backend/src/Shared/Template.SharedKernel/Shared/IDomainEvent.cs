using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.SharedKernel.Shared
{
    public interface IDomainEvent : INotification
    {
    }
}
