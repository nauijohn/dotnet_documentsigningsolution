namespace DocumentSigningSolution.Application.Documents.Commands.UpdateDocument;
public record UpdateDocumentCommand(
    string DocumentId,
    string Name,
    string Path,
    string Status,
    Stream Stream,
    string? TemplateId,
    string? FolderId) : IRequest<ErrorOr<Document>>;