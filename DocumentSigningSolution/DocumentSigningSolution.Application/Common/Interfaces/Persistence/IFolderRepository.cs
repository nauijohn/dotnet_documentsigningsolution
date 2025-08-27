using DocumentSigningSolution.Application.Common.Interfaces.Persistence.Generics;
using DocumentSigningSolution.Domain.FolderAggregate;
using DocumentSigningSolution.Domain.FolderAggregate.ValueObjects;

namespace DocumentSigningSolution.Application.Common.Interfaces.Persistence;

public interface IFolderRepository : IRepository<Folder, FolderId, Guid>
{

}