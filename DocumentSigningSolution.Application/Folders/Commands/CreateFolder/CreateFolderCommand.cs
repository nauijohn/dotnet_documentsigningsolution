using DocumentSigningSolution.Domain.FolderAggregate;

namespace DocumentSigningSolution.Application.Folders.Commands.CreateFolder;

public record CreateFolderCommand(string Path) : IRequest<ErrorOr<Folder>>;
