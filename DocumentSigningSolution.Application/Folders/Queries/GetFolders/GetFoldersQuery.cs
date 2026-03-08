using DocumentSigningSolution.Domain.FolderAggregate;

namespace DocumentSigningSolution.Application.Folders.Queries.GetFolders;

public record GetFoldersQuery() : IRequest<ErrorOr<List<Folder>>>;