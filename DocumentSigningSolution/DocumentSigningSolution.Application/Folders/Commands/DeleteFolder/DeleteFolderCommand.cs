namespace DocumentSigningSolution.Application.Folders.Commands.DeleteFolder;

public record DeleteFolderCommand(string Id) : IRequest<ErrorOr<Unit>>;