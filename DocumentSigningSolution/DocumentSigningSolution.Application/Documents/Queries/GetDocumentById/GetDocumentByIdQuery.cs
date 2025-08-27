namespace DocumentSigningSolution.Application.Documents.Queries.GetDocumentById;
public record GetDocumentByIdQuery(string DocumentId) : IRequest<ErrorOr<Document>>;