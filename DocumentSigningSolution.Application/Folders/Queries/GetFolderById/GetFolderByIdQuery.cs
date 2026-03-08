using DocumentSigningSolution.Domain.FolderAggregate;

namespace DocumentSigningSolution.Application.Folders.Queries.GetFolderById;

public record GetFolderByIdQuery(string Id) : IRequest<ErrorOr<Folder>>;