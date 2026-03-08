using DocumentSigningSolution.Application.Common.Interfaces.Persistence.Generics;
using DocumentSigningSolution.Domain.Common.Models;
using DocumentSigningSolution.Domain.Common.Models.Identities;

namespace DocumentSigningSolution.Infrastructure.Persistence.Repositories.Generics;
public class Repository<TAggregate, TId, TIdType>(DbContext _dbContext)
    : IRepository<TAggregate, TId, TIdType>
    where TAggregate : AggregateRoot<TId, TIdType>
    where TId : AggregateRootId<TIdType>
{
    private readonly DbSet<TAggregate> _dbSet = _dbContext.Set<TAggregate>();

    public async Task CreateAsync(TAggregate entity)
    {
        await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(TAggregate entity)
    {
        _dbSet.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IQueryable<TAggregate>> GetAllAsync()
    {
        await Task.CompletedTask;
        return _dbSet.AsQueryable().AsNoTracking();
    }

    public async Task<TAggregate?> GetByIdAsync(TId id)
    {
        return await _dbSet.FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task UpdateAsync(TAggregate entity)
    {
        _dbSet.Update(entity);
        await _dbContext.SaveChangesAsync();
    }
}
