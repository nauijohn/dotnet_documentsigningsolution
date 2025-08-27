using DocumentSigningSolution.Domain.Common.Models;
using DocumentSigningSolution.Domain.Common.Models.Identities;

namespace DocumentSigningSolution.Application.Common.Interfaces.Persistence.Generics;
public interface IRepository<TAggregate, in TId, TIdType>
    where TAggregate : AggregateRoot<TId, TIdType>
    where TId : AggregateRootId<TIdType>
{
    Task CreateAsync(TAggregate document);
    Task<IQueryable<TAggregate>> GetAllAsync();
    Task<TAggregate?> GetByIdAsync(TId id);
    Task UpdateAsync(TAggregate document);
    Task DeleteAsync(TAggregate document);
}
