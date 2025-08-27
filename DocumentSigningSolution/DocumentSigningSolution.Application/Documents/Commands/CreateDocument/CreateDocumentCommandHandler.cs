using DocumentSigningSolution.Domain.FolderAggregate.ValueObjects;
using DocumentSigningSolution.Domain.TemplateAggregate.ValueObjects;

namespace DocumentSigningSolution.Application.Documents.Commands.CreateDocument;

public class CreateDocumentCommandHandler(
    IDocumentRepository _documentRepository,
    IDocumentStorage _documentStorage)
    : IRequestHandler<CreateDocumentCommand, ErrorOr<Document>>
{
    public async Task<ErrorOr<Document>> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
    {
        var templateId = TemplateId.Create(request.TemplateId);
        if (templateId.IsError)
        {
            return templateId.Errors;
        }
        
        var folderId = FolderId.Create(request.FolderId);
        if (folderId.IsError)
        {
            return folderId.Errors;
        }
        
        var document = Document.Create(
            request.Title,
            request.FilePath,
            DocumentStatus.Draft,
            templateId.Value,
            folderId.Value);

        await Task.WhenAll(
            _documentRepository.CreateAsync(document),
            _documentStorage.CreateAsync(document.Id.Value.ToString(), request.Stream));

        return document;
    }
}