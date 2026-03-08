using DocumentSigningSolution.Domain.FolderAggregate;
using DocumentSigningSolution.Domain.FolderAggregate.ValueObjects;

namespace DocumentSigningSolution.Application.Folders.Queries.GetFolderById;

public class GetFolderByIdQueryHandler(IFolderRepository _folderRepository)
    : IRequestHandler<GetFolderByIdQuery, ErrorOr<Folder>>
{
    public async Task<ErrorOr<Folder>> Handle(GetFolderByIdQuery request, CancellationToken cancellationToken)
    {
        var id = FolderId.Create(request.Id);
        if (id.IsError)
        {
            return id.Errors;
        }

        var folder = await _folderRepository.GetByIdAsync(id.Value);
        if (folder is null)
        {
            return Errors.Folder.NotFound;
        }

        return folder;
    }
}