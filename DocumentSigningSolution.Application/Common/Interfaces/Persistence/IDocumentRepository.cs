using DocumentSigningSolution.Application.Common.Interfaces.Persistence.Generics;

namespace DocumentSigningSolution.Application.Common.Interfaces.Persistence;
public interface IDocumentRepository : IRepository<Document, DocumentId, Guid>
{
    Task<Document?> GetById2Async(DocumentId id);
}
