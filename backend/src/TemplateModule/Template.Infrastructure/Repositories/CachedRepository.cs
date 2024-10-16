using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Template.Application.Repositories;
using Template.Domain.Aggregate;
using Template.Domain.Ids;
using Template.SharedKernel.Shared;

namespace Template.Infrastructure.Repositories
{
    public class CachedRepository : IRepository
    {
        private readonly Repository _decorated;
        private readonly IDistributedCache _distributedCache;

        public CachedRepository(
            Repository decorated,
            IDistributedCache distributedCache)
        {
            _decorated = decorated;
            _distributedCache = distributedCache;
        }

        public Task<Result<LibrarianId>> Create(Librarian entity, CancellationToken cancellationToken = default)
        {
            return _decorated.Create(entity, cancellationToken);
        }

        public Task<Result<LibrarianId>> Delete(Librarian entity)
        {
            return _decorated.Delete(entity);
        }

        public Task<Result<List<Librarian>>> Get(CancellationToken cancellationToken = default)
        {
            return _decorated.Get(cancellationToken);
        }

        public Task<Result<Librarian>> GetByEmail(string email, CancellationToken cancellationToken = default)
        {
            return _decorated.GetByEmail(email, cancellationToken);
        }

        public Task<Result<Librarian>> GetById(LibrarianId id, CancellationToken cancellationToken = default)
        {
            return _decorated.GetById(id, cancellationToken);
        }

        public async Task<Result<Librarian?>> GetByPhoneNumber(string phone, CancellationToken cancellationToken = default)
        {
            string key = $"librarian-{phone}";

            string? cachedLibrarian = await _distributedCache.GetStringAsync(key, cancellationToken);

            Librarian? librarian;
            if(string.IsNullOrWhiteSpace(cachedLibrarian))
            {
                librarian = (await _decorated.GetByPhoneNumber(phone, cancellationToken)).Value;
                
                if(librarian is null)
                {
                    return librarian;
                }

                await _distributedCache.SetStringAsync(key, JsonSerializer.Serialize(librarian), cancellationToken);

                return librarian;
            }

            librarian = JsonSerializer.Deserialize<Librarian>(
                cachedLibrarian,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                });

            return librarian;
        }

        public Task<Result<LibrarianId>> Save(Librarian entity)
        {
            return _decorated.Save(entity);
        }
    }
}
