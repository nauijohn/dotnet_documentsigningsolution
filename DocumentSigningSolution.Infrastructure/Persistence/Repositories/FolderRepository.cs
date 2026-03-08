using DocumentSigningSolution.Domain.FolderAggregate;
using DocumentSigningSolution.Domain.FolderAggregate.ValueObjects;
using DocumentSigningSolution.Infrastructure.Persistence.Repositories.Generics;

namespace DocumentSigningSolution.Infrastructure.Persistence.Repositories;

public class FolderRepository(DocumentSigningSolutionDbContext _dbContext)
    : Repository<Folder, FolderId, Guid>(_dbContext), IFolderRepository
{

}