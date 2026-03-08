namespace DocumentSigningSolution.Application.Documents.Queries.GetDocumentById;
public class GetDocumentByIdQueryHandler(IDocumentRepository _documentRepository)
    : IRequestHandler<GetDocumentByIdQuery, ErrorOr<Document>>
{
    public async Task<ErrorOr<Document>> Handle(GetDocumentByIdQuery request, CancellationToken cancellationToken)
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

        return document;
    }
}
