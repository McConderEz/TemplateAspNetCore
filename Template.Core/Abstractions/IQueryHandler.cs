using Template.SharedKernel.Shared;

namespace Template.Core.Abstractions;

public interface IQueryHandler<TResponse, in TQuery> where TQuery : IQuery
{
    public Task<Result<TResponse>> Handle(TQuery query, CancellationToken cancellationToken = default);
}