namespace DocumentSigningSolution.Application.Documents.Commands.CreateDocument;
public record CreateDocumentCommand(
    string Title,
    string FilePath,
    Stream Stream,
    string TemplateId,
    string FolderId) : IRequest<ErrorOr<Document>>;