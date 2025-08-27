using DocumentSigningSolution.Domain.TemplateAggregate;
using DocumentSigningSolution.Domain.TemplateAggregate.ValueObjects;
using DocumentSigningSolution.Infrastructure.Persistence.Repositories.Generics;

namespace DocumentSigningSolution.Infrastructure.Persistence.Repositories;
public class TemplateRepository(DocumentSigningSolutionDbContext _dbContext)
    : Repository<Template, TemplateId, Guid>(_dbContext), ITemplateRepository
{

}
