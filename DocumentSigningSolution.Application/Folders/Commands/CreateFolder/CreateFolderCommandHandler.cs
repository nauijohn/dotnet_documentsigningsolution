using DocumentSigningSolution.Domain.FolderAggregate;

namespace DocumentSigningSolution.Application.Folders.Commands.CreateFolder;

public class CreateFolderCommandHandler(IFolderRepository _folderRepository)
    : IRequestHandler<CreateFolderCommand, ErrorOr<Folder>>
{
    public async Task<ErrorOr<Folder>> Handle(CreateFolderCommand request, CancellationToken cancellationToken)
    {
        var folder = Folder.Create(
            request.Path);
        await _folderRepository.CreateAsync(folder);
        return folder;
    }
}
