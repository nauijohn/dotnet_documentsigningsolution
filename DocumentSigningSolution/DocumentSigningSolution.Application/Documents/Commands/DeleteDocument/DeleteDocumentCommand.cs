namespace DocumentSigningSolution.Application.Documents.Commands.DeleteDocument;
public record DeleteDocumentCommand(string DocumentId) : IRequest<ErrorOr<Unit>>;
