using DocumentSigningSolution.Domain.FolderAggregate.ValueObjects;

namespace DocumentSigningSolution.Application.Folders.Commands.DeleteFolder;

public class DeleteFolderCommandHandler(IFolderRepository _folderRepository)
    : IRequestHandler<DeleteFolderCommand, ErrorOr<Unit>>
{
    public async Task<ErrorOr<Unit>> Handle(DeleteFolderCommand request, CancellationToken cancellationToken)
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

        await _folderRepository.DeleteAsync(folder);

        return Unit.Value;
    }
}