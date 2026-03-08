using DocumentSigningSolution.Infrastructure.Persistence.Repositories.Generics;

namespace DocumentSigningSolution.Infrastructure.Persistence.Repositories;
public class DocumentRepository(DocumentSigningSolutionDbContext _dbContext) 
    : Repository<Document, DocumentId, Guid>(_dbContext), IDocumentRepository
{
    public async Task<Document?> GetById2Async(DocumentId id)
    {
        return await _dbContext.Documents.Include(d => d.Folder)
            .FirstOrDefaultAsync(d => d.Id == id);
    }
}
