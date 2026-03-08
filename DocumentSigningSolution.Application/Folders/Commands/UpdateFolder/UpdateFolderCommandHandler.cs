using DocumentSigningSolution.Domain.FolderAggregate;
using DocumentSigningSolution.Domain.FolderAggregate.ValueObjects;

namespace DocumentSigningSolution.Application.Folders.Commands.UpdateFolder;

public class UpdateFolderCommandHandler(IFolderRepository _folderRepository)
    : IRequestHandler<UpdateFolderCommand, ErrorOr<Folder>>
{
    public async Task<ErrorOr<Folder>> Handle(UpdateFolderCommand request, CancellationToken cancellationToken)
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
        
        var newFolder = Folder.Update(folder, request.Adapt<Folder>());

        await _folderRepository.UpdateAsync(newFolder);

        return newFolder;
    }
}