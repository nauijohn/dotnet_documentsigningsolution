using DocumentSigningSolution.Domain.FolderAggregate;

namespace DocumentSigningSolution.Application.Folders.Queries.GetFolders;

public class GetFoldersQueryHandler(IFolderRepository _folderRepository)
    : IRequestHandler<GetFoldersQuery, ErrorOr<List<Folder>>>
{
    public async Task<ErrorOr<List<Folder>>> Handle(GetFoldersQuery request, CancellationToken cancellationToken)
    {
        var folder = await _folderRepository.GetAllAsync();
        return folder.ToList();
    }
}