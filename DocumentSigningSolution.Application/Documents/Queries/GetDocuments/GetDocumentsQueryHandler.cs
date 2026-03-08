namespace DocumentSigningSolution.Application.Documents.Queries.GetDocuments;

public class GetDocumentsQueryHandler(IDocumentRepository _documentRepository)
    : IRequestHandler<GetDocumentsQuery, ErrorOr<List<Document>>>
{
    public async Task<ErrorOr<List<Document>>> Handle(GetDocumentsQuery request, CancellationToken cancellationToken)
    {
        return (await _documentRepository.GetAllAsync()).ToList();
    }
}
