using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Aggregate;
using Template.Domain.Ids;
using Template.SharedKernel.Shared;

namespace Template.Application.Repositories
{
    public interface IRepository
    {
        Task<Result<LibrarianId>> Create(Librarian entity, CancellationToken cancellationToken = default);
        Task<Result<LibrarianId>> Delete(Librarian entity);
        Task<Result<LibrarianId>> Save(Librarian entity);
        Task<Result<Librarian>> GetById(LibrarianId id, CancellationToken cancellationToken = default);
        Task<Result<Librarian?>> GetByPhoneNumber(string phone, CancellationToken cancellationToken = default);
        Task<Result<Librarian>> GetByEmail(string email, CancellationToken cancellationToken = default);
        Task<Result<List<Librarian>>> Get(CancellationToken cancellationToken = default);
    }
}
