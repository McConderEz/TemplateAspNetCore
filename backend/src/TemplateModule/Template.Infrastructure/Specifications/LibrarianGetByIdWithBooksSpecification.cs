using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Template.Core.Specifications;
using Template.Domain.Aggregate;
using Template.Domain.Ids;

namespace Template.Infrastructure.Specifications
{
    internal class LibrarianGetByIdWithBooksSpecification : Specification<Librarian, LibrarianId>
    {
        public LibrarianGetByIdWithBooksSpecification(string phoneNumber)
            :base(librarian => librarian.PhoneNumber == phoneNumber)
        {
            AddInclude(librarian => librarian.Books);
        }
    }
}
