using DocumentSigningSolution.Application.Common.Interfaces.Persistence.Generics;
using DocumentSigningSolution.Domain.TemplateAggregate;
using DocumentSigningSolution.Domain.TemplateAggregate.ValueObjects;

namespace DocumentSigningSolution.Application.Common.Interfaces.Persistence;
public interface ITemplateRepository : IRepository<Template, TemplateId, Guid>
{

}
