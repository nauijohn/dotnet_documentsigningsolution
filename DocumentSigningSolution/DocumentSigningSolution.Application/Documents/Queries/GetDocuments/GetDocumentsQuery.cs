namespace DocumentSigningSolution.Application.Documents.Queries.GetDocuments;

public record GetDocumentsQuery() : IRequest<ErrorOr<List<Document>>>;