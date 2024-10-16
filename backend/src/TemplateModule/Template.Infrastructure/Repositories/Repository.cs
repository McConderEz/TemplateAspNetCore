using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.Repositories;
using Template.Domain.Aggregate;
using Template.Domain.Ids;
using Template.Infrastructure.DbContexts;
using Template.SharedKernel.Shared;

namespace Template.Infrastructure.Repositories;

internal class Repository : IRepository
{
    private readonly WriteDbContext _context;

    public Repository(WriteDbContext context)
    {
        _context = context;
    }


    public async Task<Result<LibrarianId>> Create(Librarian entity, CancellationToken cancellationToken = default)
    {
        await _context.Librarians.AddAsync(entity, cancellationToken);

        return entity.Id;
    }

    public Task<Result<LibrarianId>> Delete(Librarian entity)
    {
        _context.Remove(entity);

        return Task.FromResult<Result<LibrarianId>>(entity.Id);
    }

    public async Task<Result<List<Librarian>>> Get(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<Librarian>> GetByEmail(string email, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<Librarian>> GetById(LibrarianId id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<Librarian>> GetByPhoneNumber(string phone, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Result<LibrarianId>> Save(Librarian entity)
    {
        _context.Librarians.Attach(entity);

        return Task.FromResult<Result<LibrarianId>>(entity.Id);
    }
}

