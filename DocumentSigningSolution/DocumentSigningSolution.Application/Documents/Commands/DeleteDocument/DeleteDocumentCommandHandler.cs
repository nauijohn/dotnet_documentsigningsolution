using DocumentSigningSolution.Infrastructure.Storage;

namespace DocumentSigningSolution.Application.Documents.Commands.DeleteDocument;
public class DeleteDocumentCommandHandler(
    IDocumentRepository _documentRepository,
    IDocumentStorage _documentStorage)
    : IRequestHandler<DeleteDocumentCommand, ErrorOr<Unit>>
{
    public async Task<ErrorOr<Unit>> Handle(DeleteDocumentCommand request, CancellationToken cancellationToken)
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

        await Task.WhenAll(
            _documentRepository.DeleteAsync(document),
            _documentStorage.DeleteByIdAsync(documentId.Value.Value.ToString())
        );
        
        return Unit.Value;
    }
}