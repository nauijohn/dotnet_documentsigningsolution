using DocumentSigningSolution.Domain.FolderAggregate;

namespace DocumentSigningSolution.Application.Folders.Commands.UpdateFolder;

public record UpdateFolderCommand(string Id, string Path) : IRequest<ErrorOr<Folder>>;