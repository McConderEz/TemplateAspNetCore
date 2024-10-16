using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.SharedKernel.Shared;

namespace Template.Domain.Ids
{
    public class LibrarianId(Guid id): BaseId<LibrarianId>(id);
}
