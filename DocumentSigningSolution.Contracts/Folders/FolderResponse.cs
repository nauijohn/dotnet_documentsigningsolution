namespace DocumentSigningSolution.Contracts.Folders;

public record FolderResponse(
    string Id,
    string Path,
    DateTime CreatedAt,
    DateTime UpdatedAt);