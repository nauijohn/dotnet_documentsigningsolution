namespace DocumentSigningSolution.Application.Documents.Commands.UpdateDocument;

public class UpdateDocumentCommandHandler(IDocumentRepository _documentRepository, IDocumentStorage _documentStorage)
    : IRequestHandler<UpdateDocumentCommand, ErrorOr<Document>>
{
    public async Task<ErrorOr<Document>> Handle(UpdateDocumentCommand request, CancellationToken cancellationToken)
    {
        var documentId = DocumentId.Create(request.DocumentId);
        if (documentId.IsError)
        {
            return documentId.Errors;
        }
        var document = await _documentRepository.GetByIdAsync(documentId.Value);
        if (document is null)
        {
            return Errors.Document.NotFound;
        }

        var updatedDocument = request.Adapt<Document>();
        var newDocument = Document.Update(document, updatedDocument);

        await _documentRepository.UpdateAsync(newDocument);
        if (request?.Stream is not null)
        {
            await _documentStorage.UpdateAsync(document.Id.Value.ToString(), request.Stream);
        }

        return newDocument;
    }
}