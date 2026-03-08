namespace DocumentSigningSolution.Application.Documents.Queries.DownloadDocumentById;
public record DownloadDocumentByIdQuery(string Id) : IRequest<ErrorOr<Stream>>;